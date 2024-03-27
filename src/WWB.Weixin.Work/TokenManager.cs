using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WWB.Weixin.Work.Apis.Service;
using WWB.Weixin.Work.Apis.Service.Dtos;
using WWB.Weixin.Work.Apis.Token;
using WWB.Weixin.Work.Extensions;
using WWB.Weixin.Work.Models;

namespace WWB.Weixin.Work
{
    public class TokenManager : ITokenManager
    {
        private readonly WxWorkOptions _options;
        private readonly WxWorkFuncs _weixinWorkFuncs;
        private readonly IDistributedCache _cache;
        private readonly IServiceApi _serviceApi;

        private readonly ITokenApi _tokenApi;

        public TokenManager(WxWorkFuncs weixinWorkFuncs, IDistributedCache cache, IServiceApi serviceApi, ITokenApi tokenApi)
        {
            _weixinWorkFuncs = weixinWorkFuncs;
            _options = weixinWorkFuncs.GetWxWorkOptions();
            _serviceApi = serviceApi;
            _cache = cache;
            _tokenApi = tokenApi;
        }

        public async Task<string> GetProviderToken()
        {
            var cacheKey = $"TOKEN_{_options.CorpId}@{_options.ProviderSecret}";
            return await _cache.GetToken(cacheKey, async () =>
            {
                var result = await _serviceApi.GetProviderToken(new GetProviderTokenRequest
                {
                    Corpid = _options.CorpId,
                    ProviderSecret = _options.ProviderSecret
                });

                if (!result.IsSuccess())
                {
                    throw new WxWorkException($"获取服务商access_token失败！ errcode={result.ErrCode} errmsg={result.ErrMsg}");
                }

                return new TokenResult(result.ProviderAccessToken, result.ExpiresIn);
            });
        }

        public async Task<string> GetSuiteToken()
        {
            var ticket = await _weixinWorkFuncs.GetSuiteTicket(_options.SuiteId);
            if (string.IsNullOrWhiteSpace(ticket))
            {
                throw new WxWorkException($"获取代开发应用模板access_token异常！ suite_ticket is empty!");
            }
            var cacheKey = $"TOKEN_{_options.SuiteId}@{_options.SuiteSecret}";
            return await _cache.GetToken(cacheKey, async () =>
            {
                var result = await _serviceApi.GetSuiteToken(new GetSuiteTokenRequest
                {
                    SuiteId = _options.SuiteId,
                    SuiteSecret = _options.SuiteSecret,
                    SuiteTicket = ticket
                });
                if (!result.IsSuccess())
                {
                    throw new WxWorkException($"获取代开发应用模板access_token异常！ errcode={result.ErrCode} errmsg={result.ErrMsg}");
                }

                return new TokenResult(result.SuiteAccessToken, result.ExpiresIn);
            });
        }

        public async Task<string> GetToken(string corpId, string corpsecret)
        {
            var cacheKey = $"TOKEN_{corpId}@{corpsecret}";
            return await _cache.GetToken(cacheKey, async () =>
            {
                var result = await _tokenApi.GetToken(corpId, corpsecret);
                if (!result.IsSuccess())
                {
                    throw new WxWorkException($"获取代开发授权应用access_token异常！ errcode={result.ErrCode} errmsg={result.ErrMsg}");
                }

                return new TokenResult(result.AccessToken, result.ExpiresIn);
            });
        }
    }
}