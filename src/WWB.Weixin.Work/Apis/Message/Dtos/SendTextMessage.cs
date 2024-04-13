using Newtonsoft.Json;

namespace WWB.Weixin.Work.Apis.Message.Dtos
{
    public class SendTextMessage : SendMessageBase
    {
        public SendTextMessage() : base(MessageTypes.text)
        {
        }

        [JsonProperty("text")]
        public TextInfo text { get; set; }

        [JsonProperty("safe")]
        public int safe { get; set; }

        [JsonProperty("enable_id_trans")]
        public int enable_id_trans { get; set; }

        public class TextInfo
        {
            [JsonProperty("content")]
            public string content { get; set; }
        }
    }
}