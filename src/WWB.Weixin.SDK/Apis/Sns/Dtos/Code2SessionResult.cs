using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WWB.Weixin.SDK.Apis.Sns.Dtos
{
    public class Code2SessionResult : ApiResultBase
    {
        [JsonProperty(PropertyName = "openid")]
        public string Openid { get; set; }

        [JsonProperty("session_key")]
        public string SessionKey { get; set; }

        [JsonProperty(PropertyName = "unionid")]
        public string UnionId { get; set; }
    }
}
