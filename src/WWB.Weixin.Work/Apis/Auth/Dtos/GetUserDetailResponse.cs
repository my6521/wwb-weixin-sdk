using Newtonsoft.Json;

namespace WWB.Weixin.Work.Apis.Auth.Dtos
{
    public class GetUserDetailResponse : ApiResultBase
    {
        [JsonProperty("userid")]
        public string UserId { get; set; }

        [JsonProperty("gender")]
        public int Gender { get; set; }

        [JsonProperty("avatar")]
        public string Avatar { get; set; }

        [JsonProperty("mobile")]
        public string Mobile { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("biz_mail")]
        public string BizMail { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }
    }
}