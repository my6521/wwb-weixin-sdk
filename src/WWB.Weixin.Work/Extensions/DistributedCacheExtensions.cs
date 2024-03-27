using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WWB.Weixin.Work.Models;

namespace WWB.Weixin.Work.Extensions
{
    public static class DistributedCacheExtensions
    {
        public static async Task<string> GetToken(this IDistributedCache cache, string key, Func<Task<TokenResult>> initFunc)
        {
            var result = await cache.GetStringAsync(key);
            if (!string.IsNullOrEmpty(result))
            {
                return result;
            }

            var tokenResult = await initFunc();
            result = tokenResult.AccessToken;
            await cache.SetStringAsync(key, tokenResult.AccessToken, new DistributedCacheEntryOptions
            {
                AbsoluteExpiration = DateTimeOffset.Now.Add(TimeSpan.FromSeconds(tokenResult.ExpiresIn)),
            });

            return result;
        }
    }
}