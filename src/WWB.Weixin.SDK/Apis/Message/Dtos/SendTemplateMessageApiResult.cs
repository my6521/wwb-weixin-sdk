using Newtonsoft.Json;

namespace WWB.Weixin.SDK.Apis.Message
{
    public class SendTemplateMessageApiResult : ApiResultBase
    {
        [JsonProperty("msgid")]
        public string MessageId { get; set; }
    }
}