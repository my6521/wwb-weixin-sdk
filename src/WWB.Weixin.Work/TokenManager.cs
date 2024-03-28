using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WWB.Weixin.Work.Apis.Service;
using WWB.Weixin.Work.Apis.Service.Dtos;
using WWB.Weixin.Work.Apis.Token;
using WWB.Weixin.Work.Models;

namespace WWB.Weixin.Work
{
    /// <summary>
    ///
    /// </summary>
    public class TokenManager : ITokenManager
    {
        private readonly WxWorkFuncs _wxWorkFuncs;
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        ///
        /// </summary>
        /// <param name="wxWorkFuncs"></param>
        /// <param name="serviceProvider"></param>
        public TokenManager(WxWorkFuncs wxWorkFuncs, IServiceProvider serviceProvider)
        {
            _wxWorkFuncs = wxWorkFuncs;
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// 获取服务商凭据
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetProviderAccessToken()
        {
            var options = _wxWorkFuncs?.GetWxWorkOptions();
            var token = _wxWorkFuncs?.GetProviderAccessToken(options.CorpId);
            if (string.IsNullOrEmpty(token))
            {
                IServiceApi serviceApi = _serviceProvider.GetService<IServiceApi>();
                var result = await serviceApi.GetProviderToken(new GetProviderTokenRequest
                {
                    Corpid = options.CorpId,
                    ProviderSecret = options.ProviderSecret
                });
                _wxWorkFuncs?.CacheProviderAccessToken(options.CorpId, result.ProviderAccessToken);
                return result.ProviderAccessToken;
            }

            return token;
        }

        /// <summary>
        /// 获取应用凭据
        /// </summary>
        /// <returns></returns>
        /// <exception cref="WxWorkException"></exception>
        public async Task<string> GetSuiteAccessToken()
        {
            var options = _wxWorkFuncs?.GetWxWorkOptions();
            var ticket = await _wxWorkFuncs?.GetSuiteTicket(options.SuiteId);
            if (string.IsNullOrWhiteSpace(ticket))
                throw new WxWorkException($"获取代开发应用模板access_token异常！ suite_ticket is empty!");

            var token = _wxWorkFuncs?.GetSuiteAccessToken(options.SuiteId);
            if (string.IsNullOrEmpty(token))
            {
                IServiceApi serviceApi = _serviceProvider.GetService<IServiceApi>();
                var result = await serviceApi.GetSuiteToken(new GetSuiteTokenRequest
                {
                    SuiteId = options.SuiteId,
                    SuiteSecret = options.SuiteSecret,
                    SuiteTicket = ticket
                });
                _wxWorkFuncs?.CacheSuiteAccessToken(options.SuiteId, result.SuiteAccessToken);
                return result.SuiteAccessToken;
            }

            return token;
        }

        /// <summary>
        /// 获取企业应用凭据
        /// </summary>
        /// <param name="corpId"></param>
        /// <param name="corpsecret"></param>
        /// <returns></returns>
        /// <exception cref="WxWorkException"></exception>
        public async Task<string> GetAccessToken(string corpId, string corpsecret)
        {
            var options = _wxWorkFuncs?.GetWxWorkOptions();
            var token = _wxWorkFuncs?.GetAccessToken(corpId, corpsecret);
            if (string.IsNullOrWhiteSpace(token))
            {
                ITokenApi tokenApi = _serviceProvider.GetService<ITokenApi>();
                var result = await tokenApi.GetToken(corpId, corpsecret);
                _wxWorkFuncs?.CacheAccessToken(corpId, corpsecret, result.AccessToken);
                return result.AccessToken;
            }

            return token;
        }
    }
}