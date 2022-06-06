using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Linq;

namespace SessionExtendMiddleware.Extensions
{
    internal static class HttpContextExtensions
    {
        public static string GetToken(this HttpContext context)
        {
            var serr = context.Request.Headers["Authorization"];
            StringValues tokenValues;
            var keys = context.Request.Headers.Keys;
            if (!keys.Any(s => s.Equals("Authorization", StringComparison.OrdinalIgnoreCase))) return tokenValues.ToString();
            {
                var parameterKey = keys.FirstOrDefault(s => s.Equals("Authorization", StringComparison.OrdinalIgnoreCase));
                if (!string.IsNullOrEmpty(parameterKey))
                {
                    context.Request.Headers.TryGetValue(parameterKey, out tokenValues);
                }
            }
            return tokenValues.ToString().Split(" ").Last();
        }
    }
}
