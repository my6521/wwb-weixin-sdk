using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace WWB.Weixin.Work.Apis.Message.Dtos
{
    public abstract class SendMessageBase
    {
        protected SendMessageBase(MessageTypes msgtype)
        {
            this.msgtype = msgtype;
        }

        [JsonProperty("touser")]
        public string touser { get; set; }

        [JsonProperty("toparty")]
        public string toparty { get; set; }

        [JsonProperty("totag")]
        public string totag { get; set; }

        [JsonProperty("msgtype")]
        [JsonConverter(typeof(StringEnumConverter))]
        public MessageTypes msgtype { get; set; }

        [JsonProperty("agentid")]
        public int? agentid { get; set; }

        [JsonProperty("enable_duplicate_check")]
        public int enable_duplicate_check { get; set; } = 0;

        [JsonProperty("duplicate_check_interval")]
        public int duplicate_check_interval { get; set; } = 1800;
    }
}