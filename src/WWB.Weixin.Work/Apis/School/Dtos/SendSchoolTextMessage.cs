using Newtonsoft.Json;

namespace WWB.Weixin.Work.Apis.School.Dtos
{
    public class SendSchoolTextMessage : SendSchoolMessageBase
    {
        public SendSchoolTextMessage() : base(SchoolMessageTypes.text)
        {
        }

        [JsonProperty("text")]
        public TextInfo text { get; set; }

        [JsonProperty("enable_id_trans")]
        public int enable_id_trans { get; set; }

        public class TextInfo
        {
            [JsonProperty("content")]
            public string content { get; set; }
        }
    }
}