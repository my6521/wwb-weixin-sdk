using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WWB.Weixin.Work.Apis.Service.Dtos
{
    public class GetAuthInfoRequest
    {
        [JsonProperty("auth_corpid")]
        public string AuthCorpid { get; set; }

        [JsonProperty("permanent_code")]
        public string PermanentCode { get; set; }
    }
}