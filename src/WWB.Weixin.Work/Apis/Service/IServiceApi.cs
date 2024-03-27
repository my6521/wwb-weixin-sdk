using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiClientCore.Attributes;
using WWB.Weixin.Work.Apis.Service.Dtos;
using WWB.Weixin.Work.Apis.Token.Dtos;

namespace WWB.Weixin.Work.Apis.Service
{
    public interface IServiceApi : IBaseHttpApi
    {
        /// <summary>
        /// 获取服务商凭证
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("/cgi-bin/service/get_provider_token")]
        Task<GetProviderTokenResponse> GetProviderToken([JsonNetContent] GetProviderTokenRequest request);

        /// <summary>
        /// 获取代开发应用模板凭证
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("/cgi-bin/service/get_suite_token")]
        Task<GetSuiteTokenResponse> GetSuiteToken([JsonNetContent] GetSuiteTokenRequest request);

        /// <summary>
        /// 代开发授权应用secret的获取
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("/cgi-bin/service/get_permanent_code")]
        [SuiteAccessTokenFilter]
        Task<GetPermanentCodeResponse> GetPermanentCode([JsonNetContent] GetPermanentCodeRequest request);

        /// <summary>
        /// 获取企业授权信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("/cgi-bin/service/get_auth_info")]
        [SuiteAccessTokenFilter]
        Task<GetAuthInfoReponse> GetAuthInfo([JsonNetContent] GetAuthInfoRequest request);

        /// <summary>
        /// 获取带参授权链接
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("/cgi-bin/service/get_customized_auth_url")]
        [ProviderAccessTokenFilter]
        Task<GetCustomizedAuthUrlResponse> GetCustomizedAuthUrl([JsonNetContent] GetCustomizedAuthUrlRequest request);
    }
}