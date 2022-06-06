using Microsoft.AspNetCore.Http;
using SessionExtendMiddleware.Extensions;
using SessionExtendMiddleware.PerRequest;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace SessionExtendMiddleware
{
    /// <summary>
    /// Represents base entity mapping configuration
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SessionExtendMiddleware<T> where T : class
    {
        private readonly RequestDelegate _next;
        private readonly IPerRequestCacheManager _requestCacheManager;
        public T RequestObject { get; set; }

        public SessionExtendMiddleware(RequestDelegate next, IPerRequestCacheManager requestCacheManager)
        {
            _next = next;
            _requestCacheManager = requestCacheManager;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var token = httpContext.GetToken();

            if (!string.IsNullOrEmpty(token))
            {
                T instanceSession = (T)typeof(T).GetConstructor(new Type[0]).Invoke(new object[0]);

                var handler = new JwtSecurityTokenHandler();

                if (handler.ReadToken(token) is JwtSecurityToken jwtToken)
                {
                    foreach (var property in typeof(T).GetProperties())
                    {
                        property.SetValue(instanceSession, jwtToken.Claims.First(claim => claim.Type == property.Name).Value);
                    }

                    _requestCacheManager.Set(token, instanceSession);
                }
            }

            await _next.Invoke(httpContext);
        }
    }
}
