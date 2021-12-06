using System;
using System.Collections.Generic;
using System.Runtime.Caching;
using System.Text;

/**
*┌────────────────────────────┐
*│　CLR 版本：4.0.30319.42000                                              
*│　作    者：詹建妹
*│　邮    箱：JameZhan@aliyun.com         
*│　部    门：自动化创新部                             
*│　创建时间：2020/8/30 11:28:05                                            
*│　版    本：V1.0.0      
*│　功能描述：                           
*└────────────────────────────┘
*┌────────────────────────────┐
*│　Copyright @ Yankon 2020. All rights reserved                                                                
*└────────────────────────────┘
*/
namespace TPCOMMGER.WindowsService
{
    /// <summary>
    ///  功能描述：缓存帮助类
    /// <para>作者：詹建妹(JameZhan@aliyun.com)</para>
    /// <para>时间：2020/8/30 11:28:05</para>
    /// </summary>
    public static class MemoryCacheHelper
    {
        private static readonly object obj = new object();

        /// <summary>
        /// 设置缓存：使用默认值，不过期
        /// </summary>
        /// <param name="cacheKey">缓存主键</param>
        /// <param name="cacheValue">缓存值</param>
        /// <returns></returns>
        public static string SetCache(string cacheKey, object cacheValue)
        {
            if (string.IsNullOrWhiteSpace(cacheKey))
                return "Invalid cache key";
            if (cacheValue == null)
                return "Invalid cache value";
            // 没有缓存
            if (MemoryCache.Default[cacheKey] == null)
            {
                lock (obj)
                {
                    if (MemoryCache.Default[cacheKey] == null)
                    {
                        var item = new CacheItem(cacheKey, cacheValue);
                        var policy = new CacheItemPolicy();
                        policy.Priority = CacheItemPriority.Default;
                        MemoryCache.Default.Add(item, policy);
                    }
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// 重置缓存
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <param name="cacheValue"></param>
        /// <returns></returns>
        public static string ResetCache(string cacheKey, object cacheValue)
        {
            // 清理以往缓存
            RemoveCache(cacheKey);
            // 重置缓存数据
            return SetCache(cacheKey, cacheValue);
        }

        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <param name="cacheKey">缓存主键</param>
        /// <param name="cacheValue">缓存值</param>
        /// <param name="SlidingExpiration">滑动过期时间</param>
        /// <param name="absoluteExpiration">绝对过期时间</param>
        /// <returns></returns>
        public static string SetCache(string cacheKey, object cacheValue, TimeSpan slidingExpiration, DateTime? absoluteExpiration = null)
        {
            if (string.IsNullOrWhiteSpace(cacheKey))
                return "Invalid cache key";
            if (cacheValue == null)
                return "Invalid cache value";
            // 没有缓存
            if (MemoryCache.Default[cacheKey] == null)
            {
                lock (obj)
                {
                    if (MemoryCache.Default[cacheKey] == null)
                    {
                        var item = new CacheItem(cacheKey, cacheValue);
                        var policy = CreatePolicy(slidingExpiration, absoluteExpiration);
                        MemoryCache.Default.Add(item, policy);
                    }
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// 重置缓存
        /// </summary>
        /// <param name="cacheKey">缓存主键</param>
        /// <param name="cacheValue">缓存值</param>
        /// <param name="slidingExpiration">滑动过期时间</param>
        /// <param name="absoluteExpiration">绝对过期时间</param>
        /// <returns></returns>
        public static string ResetCache(string cacheKey, object cacheValue, TimeSpan slidingExpiration, DateTime? absoluteExpiration = null)
        {
            // 清除缓存
            RemoveCache(cacheKey);
            // 重置缓存
            return SetCache(cacheKey, cacheValue, slidingExpiration, absoluteExpiration);
        }

        /// <summary>
        /// 获取缓存值
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <returns></returns>
        public static object GetCache(string cacheKey)
        {
            if (string.IsNullOrWhiteSpace(cacheKey)) return null;
            return MemoryCache.Default[cacheKey];
        }

        /// <summary>
        /// 设置缓存并返回缓存值
        /// </summary>
        /// <typeparam name="T">缓存类型</typeparam>
        /// <param name="key">缓存主键</param>
        /// <param name="cachePopulate">缓存值表达式：用于过期数据读取</param>
        /// <param name="slidingExpiration">滑动过期时间</param>
        /// <param name="absoluteExpiration">绝对过期时间</param>
        /// <returns></returns>
        public static T FindCache<T>(string cacheKey, Func<T> cachePopulate, TimeSpan? slidingExpiration = null, DateTime? absoluteExpiration = null)
        {
            if (string.IsNullOrWhiteSpace(cacheKey))
            {
                throw new ArgumentException("Invalid cache key");
            }
            if (cachePopulate == null)
            {
                throw new ArgumentNullException("cachePopulate");
            }
            if (slidingExpiration == null && absoluteExpiration == null)
            {
                throw new ArgumentException("Either a sliding expiration or absolute must be provided");
            }

            if (MemoryCache.Default[cacheKey] == null)
            {
                lock (obj)
                {
                    if (MemoryCache.Default[cacheKey] == null)
                    {
                        var item = new CacheItem(cacheKey, cachePopulate());
                        var policy = CreatePolicy(slidingExpiration, absoluteExpiration);

                        MemoryCache.Default.Add(item, policy);
                    }
                }
            }

            return (T)MemoryCache.Default[cacheKey];
        }
        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="key"></param>
        public static void RemoveCache(string key)
        {
            if (MemoryCache.Default[key] != null)
                MemoryCache.Default.Remove(key);
        }
        /// <summary>
        /// 创建缓存策略
        /// </summary>
        /// <param name="slidingExpiration">滑动缓存时间</param>
        /// <param name="absoluteExpiration">绝对缓存时间</param>
        /// <returns></returns>
        private static CacheItemPolicy CreatePolicy(TimeSpan? slidingExpiration, DateTime? absoluteExpiration)
        {
            var policy = new CacheItemPolicy();

            if (absoluteExpiration.HasValue)
            {
                policy.AbsoluteExpiration = absoluteExpiration.Value;
            }
            else if (slidingExpiration.HasValue)
            {
                policy.SlidingExpiration = slidingExpiration.Value;
            }

            policy.Priority = CacheItemPriority.Default;

            return policy;
        }
    }
}
