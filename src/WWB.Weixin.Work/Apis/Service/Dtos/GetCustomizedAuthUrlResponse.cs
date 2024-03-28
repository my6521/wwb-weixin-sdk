using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WWB.Weixin.Work.Apis.Service.Dtos
{
    public class GetCustomizedAuthUrlResponse : ApiResultBase
    {
        [JsonProperty("qrcode_url")]
        public string QrcodeUrl { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }
    }
}