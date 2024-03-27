using Newtonsoft.Json;

namespace WWB.Weixin.SDK.Apis.CustomerService
{
    public class DelKfAccountInput
    {
        [JsonProperty("kf_account")]
        public string Account { get; set; }
    }
}