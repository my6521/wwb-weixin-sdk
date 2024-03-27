using System.Net.Http;
using System.Threading.Tasks;
using WebApiClientCore.Attributes;
using WWB.Weixin.SDK.Apis.QrCode.Dtos;

namespace WWB.Weixin.SDK.Apis.QrCode
{
    [HttpHost("https://api.weixin.qq.com/wxa/")]
    public interface IQrCodeApi : IWxApiBase
    {
        /// <summary>
        /// 接口 B: 获取小程序码，适用于需要的码数量极多的业务场景
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("getwxacodeunlimit")]
        Task<HttpResponseMessage> GetwxacodeUnlimit([PathQuery] string access_token, [JsonNetContent] GetWxacodeUnlimitRequest request);

        /// <summary>
        /// 接口 A: 获取小程序码，适用于需要的码数量较少的业务场景
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("getwxacode")]
        Task<HttpResponseMessage> Getwxacode([PathQuery] string access_token, [JsonNetContent] GetWxaCodeRequest request);
    }
}