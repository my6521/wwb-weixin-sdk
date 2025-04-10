using FreeRedis;
using System;
using System.Threading.Tasks;
using WWB.Weixin.SDK.Apis.Token;

namespace WWB.Weixin.SDK
{
    /// <summary>
    /// 公众号AccessToken管理器
    /// </summary>
    public class TokenManager : ITokenManager
    {
        private readonly WxPublicAccountOption _options;
        private readonly ITokenApi _tokenApi;
        private readonly IRedisClient _redisClient;

        public TokenManager(IRedisClient redisClient, WxPublicAccountOption options, ITokenApi tokenApi)
        {
            _redisClient = redisClient;
            _options = options;
            _tokenApi = tokenApi;
        }

        /// <summary>
        /// 获取Access Token
        /// </summary>
        /// <returns></returns>
        public virtual async Task<string> GetAccessTokenAsync()
        {
            var key = "WX:" + _options.AppId;
            if (_redisClient.Exists(key))
            {
                return await _redisClient.GetAsync<string>(key);
            }

            var result = await _tokenApi.GetAsync(_options.AppId, _options.AppSecret);
            result.EnsureSuccess();
            await _redisClient.SetAsync(key, result.AccessToken, TimeSpan.FromSeconds(result.Expires - 60));

            return result.AccessToken;
        }
    }
}