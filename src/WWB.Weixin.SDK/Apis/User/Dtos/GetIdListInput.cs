using Newtonsoft.Json;

namespace WWB.Weixin.SDK.Apis.User.Dtos
{
    public class GetIdListInput
    {
        [JsonProperty("openid")]
        public string OpenId { get; set; }
    }
}