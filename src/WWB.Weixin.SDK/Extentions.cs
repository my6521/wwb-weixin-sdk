using Microsoft.Extensions.DependencyInjection;
using System;
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
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddWxSdk(this IServiceCollection services, Action<WxPublicAccountOption> configuration)
        {
            var options = new WxPublicAccountOption();
            configuration.Invoke(options);
            services.AddSingleton(options);

            services
                .AddWebApiClient()
                .UseJsonFirstApiActionDescriptor();

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