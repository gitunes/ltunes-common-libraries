using Microsoft.AspNetCore.Http;
using SessionExtendMiddleware.Extensions;
using System;
using System.Collections.Generic;

namespace SessionExtendMiddleware.PerRequest
{
    public class PerRequestCacheManager : IPerRequestCacheManager
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public PerRequestCacheManager(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
        }
        public T Get<T>(string key)
        {
            var items = GetItems();
            if (items == null)
                return default(T);
            //item already is in cache, so return it
            if (items[key] != null)
            {
                return (T)items[key];
            }
            return default(T);
        }
        public void Set(string key, object data)
        {
            var items = GetItems();
            if (items == null)
                return;
            if (data != null)
                items[key] = data;
        }
        public bool IsSet(string key)
        {
            var items = GetItems();
            return items?[key] != null;
        }
        public void Remove(string key)
        {
            var items = GetItems();
            items?.Remove(key);
        }
        public void Clear()
        {
            var items = GetItems();
            items?.Clear();
        }

        public T GetSession<T>()
        {
            string key = HttpContext.GetToken();

            var items = GetItems();
            if (items == null)
                return default(T);
            //item already is in cache, so return it
            if (items[key] != null)
            {
                return (T)items[key];
            }
            return default(T);
        }

        public HttpContext HttpContext => _httpContextAccessor.HttpContext;

        HttpContext IPerRequestCacheManager.HttpContext => throw new NotImplementedException();

        public void Dispose()
        {
            //nothing special
        }
        protected virtual IDictionary<object, object> GetItems()
        {
            return _httpContextAccessor.HttpContext?.Items;
        }
    }
}
