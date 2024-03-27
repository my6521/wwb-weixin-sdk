using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WWB.Weixin.Work.Apis.Message.Dtos
{
    public class RecallMessageRequest
    {
        [JsonProperty("msgid")]
        public string msgid { get; set; }
    }
}