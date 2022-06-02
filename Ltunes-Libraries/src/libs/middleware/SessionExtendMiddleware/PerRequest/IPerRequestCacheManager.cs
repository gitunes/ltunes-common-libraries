using Microsoft.AspNetCore.Http;

namespace SessionExtendMiddleware.PerRequest
{
    public interface IPerRequestCacheManager
    {
        T Get<T>(string key);
        public T GetSession<T>();
        void Set(string key, object data);
        bool IsSet(string key);
        void Remove(string key);
        void Clear();
        HttpContext HttpContext { get; }
    }
}
