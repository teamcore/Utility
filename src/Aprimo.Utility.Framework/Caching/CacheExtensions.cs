using System;
using System.Runtime.Caching;

namespace Aprimo.Utility.Framework.Caching
{
    public static class CacheExtensions
    {
        public static T Get<T>(this ICacheProvider cacheProvider, string key, Func<T> acquire)
        {
            var policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = new DateTimeOffset(DateTime.Now.AddDays(60D));
            return Get(cacheProvider, key, policy, acquire);
        }

        public static T Get<T>(this ICacheProvider cacheProvider, string key, CacheItemPolicy policy, Func<T> acquire)
        {
            if (cacheProvider.IsSet(key))
            {
                return cacheProvider.Get<T>(key);
            }

            var result = acquire();
            //if (result != null)
            cacheProvider.Set(key, result, policy);
            return result;
        }
    }
}
