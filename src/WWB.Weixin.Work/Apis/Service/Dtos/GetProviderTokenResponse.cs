using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WWB.Weixin.Work.Apis.Service.Dtos
{
    public class GetProviderTokenResponse : BaseResponse
    {
        [JsonProperty("provider_access_token")]
        public string ProviderAccessToken { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }
    }
}