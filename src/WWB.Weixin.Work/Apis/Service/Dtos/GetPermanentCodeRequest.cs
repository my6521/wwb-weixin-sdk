using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WWB.Weixin.Work.Apis.Service.Dtos
{
    public class GetPermanentCodeRequest
    {
        [JsonProperty("auth_code")]
        public string AuthCode { get; set; }
    }
}