using System.Threading.Tasks;
using WebApiClientCore.Attributes;
using WWB.Weixin.SDK.Apis.Sns.Dtos;

namespace WWB.Weixin.SDK.Apis.Sns
{
    /// <summary>
    /// https://developers.weixin.qq.com/doc/offiaccount/OA_Web_Apps/Wechat_webpage_authorization.html
    /// </summary>
    [HttpHost("https://api.weixin.qq.com/sns/")]
    public interface ISnsApi : IWxApiBase
    {
        /// <summary>
        /// 拉取用户信息(需scope为 snsapi_userinfo)
        /// 如果网页授权作用域为snsapi_userinfo，则此时开发者可以通过access_token和openid拉取用户信息了。
        /// </summary>
        /// <param name="access_token">网页授权接口调用凭证,注意：此access_token与基础支持的access_token不同</param>
        /// <param name="openid"></param>
        /// <param name="lang">返回国家地区语言版本，zh_CN 简体，zh_TW 繁体，en 英语</param>
        /// <returns></returns>
        [HttpGet("userinfo")]
        Task<GetUserInfoApiResult> GetUserInfoAsync(string access_token, string openid, string lang = "zh_CN");

        /// <summary>
        /// 检验授权凭证（access_token）是否有效
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="openid"></param>
        /// <returns></returns>
        [HttpGet("auth")]
        Task<ApiResultBase> AuthAsync(string access_token, string openid);

        /// <summary>
        /// 网页通过code获取用户标识
        /// </summary>
        /// <param name="appid"></param>
        /// <param name="secret"></param>
        /// <param name="js_code"></param>
        /// <param name="grant_type"></param>
        /// <returns></returns>
        [HttpGet("jscode2session")]
        Task<Code2SessionResult> Code2session(string appid, string secret, string js_code, string grant_type = "authorization_code");
    }
}
