using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text;
using WWB.Weixin.SDK.Apis;
using WWB.Weixin.SDK.Apis.CustomerService;
using WWB.Weixin.SDK.Apis.Media;
using WWB.Weixin.SDK.Apis.Menu;
using WWB.Weixin.SDK.Apis.Message;
using WWB.Weixin.SDK.Apis.QrCode;
using WWB.Weixin.SDK.Apis.Sns;
using WWB.Weixin.SDK.Apis.Token;
using WWB.Weixin.SDK.Apis.User;
using WWB.Weixin.SDK.ServerMessages;

namespace WWB.Weixin.SDK
{
    public static class Extentions
    {
        /// <summary>
        /// 添加公众号Sdk集成
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddWxSdk(this IServiceCollection services)
        {
            services
                .AddWebApiClient()
                .UseJsonFirstApiActionDescriptor();

            services.AddSingleton<WxFuncs>();

            services.AddHttpApi<ITokenApi>();
            services.AddHttpApi<IOauth2Api>();
            services.AddHttpApi<ISnsApi>();
            services.AddHttpApi<ITemplateApi>();
            services.AddHttpApi<IMenuApi>();
            services.AddHttpApi<IKfAccountApi>();
            services.AddHttpApi<IMediaApi>();
            services.AddHttpApi<IUserApi>();
            services.AddHttpApi<ITagsApi>();
            services.AddHttpApi<IQrCodeApi>();

            services.AddSingleton<ITokenManager, TokenManager>();
            services.AddSingleton<ServerMessageHandler>();

            return services;
        }

        /// <summary>
        /// 配置公众号Sdk
        /// </summary>
        /// <param name="app"></param>
        /// <param name="setupAction"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseWxSdk(this IApplicationBuilder app, Action<WxFuncs> setupAction = null)
        {
            var cache = app.ApplicationServices.GetRequiredService<IDistributedCache>();
            WxFuncs funcs = app.ApplicationServices.GetRequiredService<WxFuncs>();
            setupAction?.Invoke(funcs);
            //如果没有设置获取微信配置逻辑，则自动从配置文件读取
            if (funcs.GetWeChatOptions == null)
            {
                IConfiguration config = app.ApplicationServices.GetRequiredService<IConfiguration>();
                IConfigurationSection wechatConfig = config.GetSection("Wx");
                if (wechatConfig != null)
                {
                    funcs.GetWeChatOptions = () =>
                    {
                        var options = new WxPublicAccountOption();
                        wechatConfig.Bind(options);
                        return options;
                    };
                }
                else
                {
                    throw new WxSdkException("公众号未配置！");
                }
            }

            if (funcs.GetAccessTokenByAppId == null)
            {
                funcs.GetAccessTokenByAppId = (appid) => cache.GetString($"{WxConsts.WX_PUBLICACCOUNT_CACHE_NAMESPACE}::AT::{appid}");
            }
            if (funcs.CacheAccessToken == null)
            {
                funcs.CacheAccessToken = (appid, token) =>
                {
                    byte[] tokenBytes = Encoding.UTF8.GetBytes(token);
                    cache.Set($"{WxConsts.WX_PUBLICACCOUNT_CACHE_NAMESPACE}::AT::{appid}", tokenBytes, new DistributedCacheEntryOptions()
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(115)
                    });
                };
            }

            return app;
        }

        /// <summary>
        /// 确保成功执行
        /// </summary>
        /// <param name="apiResult"></param>
        public static void EnsureSuccess(this ApiResultBase apiResult)
        {
            if (!apiResult.IsSuccess())
            {
                throw new WxSdkException(apiResult.GetFriendlyMessage());
            }
        }
    }
}