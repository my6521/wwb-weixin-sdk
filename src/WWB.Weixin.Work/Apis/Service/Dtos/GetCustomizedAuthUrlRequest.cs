using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WWB.Weixin.Work.Apis.Service.Dtos
{
    public class GetCustomizedAuthUrlRequest
    {
        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("templateid_list")]
        public List<string> TemplateidList { get; set; }
    }
}