using Newtonsoft.Json;

namespace WWB.Weixin.Work.Apis.Contact.Dtos
{
    public class GetUserIdByMobileRequest
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("mobile")]
        public string Mobile { get; set; }
    }
}