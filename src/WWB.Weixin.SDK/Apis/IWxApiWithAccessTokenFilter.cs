using WebApiClientCore.Attributes;

namespace WWB.Weixin.SDK.Apis
{
    /// <summary>
    /// 
    /// </summary>
    [JsonNetReturn(EnsureMatchAcceptContentType = false)]
    [AccessTokenApiFilter]
    [LoggingFilter]
    public interface IWxApiWithAccessTokenFilter
    {
    }
}
