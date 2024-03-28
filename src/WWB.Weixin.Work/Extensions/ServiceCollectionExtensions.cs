using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;
using System;
using WWB.Weixin.Work;
using WWB.Weixin.Work.Apis.Auth;
using WWB.Weixin.Work.Apis.Contact;
using WWB.Weixin.Work.Apis.Message;
using WWB.Weixin.Work.Apis.Service;
using WWB.Weixin.Work.Apis.Token;
using WWB.Weixin.Work.ServerMessages;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    ///
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddWxWork(this IServiceCollection services)
        {
            services.AddSingleton<WxWorkFuncs>();
            services.AddHttpApi<IServiceApi>();
            services.AddHttpApi<ITokenApi>();
            services.AddHttpApi<IAuthApi>();
            services.AddHttpApi<IContactApi>();
            services.AddHttpApi<IMessageApi>();

            services.AddSingleton<ITokenManager, TokenManager>();
            services.AddSingleton<ServerMessageHandler>();

            return services;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="app"></param>
        /// <param name="setupAction"></param>
        /// <returns></returns>
        /// <exception cref="WxWorkException"></exception>
        public static IApplicationBuilder UseWxWork(this IApplicationBuilder app, Action<WxWorkFuncs> setupAction = null)
        {
            var cache = app.ApplicationServices.GetRequiredService<IDistributedCache>();
            WxWorkFuncs funcs = app.ApplicationServices.GetRequiredService<WxWorkFuncs>();
            setupAction?.Invoke(funcs);
            //如果没有设置获取微信配置逻辑，则自动从配置文件读取
            if (funcs.GetWxWorkOptions == null)
            {
                IConfiguration config = app.ApplicationServices.GetRequiredService<IConfiguration>();
                IConfigurationSection wechatConfig = config.GetSection("WxWork");
                if (wechatConfig != null)
                {
                    funcs.GetWxWorkOptions = () =>
                    {
                        var options = new WxWorkOptions();
                        wechatConfig.Bind(options);
                        return options;
                    };
                }
                else
                {
                    throw new WxWorkException("企业微信未配置！");
                }
            }
            if (funcs.GetProviderToken == null)
            {
                funcs.GetProviderToken = (corpId) => cache.GetString($"WX::WORK::{corpId}");
            }
            if (funcs.GetSuiteToken == null)
            {
                funcs.GetSuiteToken = (suiteId) => cache.GetString($"WX::WORK::{suiteId}");
            }
            if (funcs.GetAccessToken == null)
            {
                funcs.GetAccessToken = (corpId, corpSecret) => cache.GetString($"WX::WORK::{corpId}#{corpSecret}");
            }
            if (funcs.CacheProviderToken == null)
            {
                funcs.CacheProviderToken = (corpId, token) =>
                {
                    cache.SetString($"WX::WORK::{corpId}", token, new DistributedCacheEntryOptions()
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(115)
                    });
                };
            }
            if (funcs.CacheSuiteToken == null)
            {
                funcs.CacheSuiteToken = (suiteId, token) =>
                {
                    cache.SetString($"WX::WORK::{suiteId}", token, new DistributedCacheEntryOptions()
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(115)
                    });
                };
            }
            if (funcs.CacheAccessToken == null)
            {
                funcs.CacheAccessToken = (corpId, corpSecret, token) =>
                {
                    cache.SetString($"WX::WORK::{corpId}#{corpSecret}", token, new DistributedCacheEntryOptions()
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(115)
                    });
                };
            }

            return app;
        }
    }
}