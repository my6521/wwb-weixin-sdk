using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WWB.Weixin.Work.Apis.Service.Dtos
{
    public class GetProviderTokenRequest
    {
        [Required]
        [JsonProperty("corpid")]
        public string Corpid { get; set; }

        [Required]
        [JsonProperty("provider_secret")]
        public string ProviderSecret { get; set; }
    }
}