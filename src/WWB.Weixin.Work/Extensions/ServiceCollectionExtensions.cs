using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
    public static class ServiceCollectionExtensions
    {
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
                        var option = new WxWorkOptions();
                        wechatConfig.Bind(option);
                        return option;
                    };
                }
                else
                {
                    throw new WxWorkException("企业微信未配置！");
                }
            }

            return app;
        }
    }
}