using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WWB.Weixin.Work.Apis.Message.Dtos
{
    public class SendMessageResponse : BaseResponse
    {
        [JsonProperty("msgid")]
        public string msgid { get; set; }

        [JsonProperty("response_code")]
        public string response_code { get; set; }
    }
}