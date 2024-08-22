using Newtonsoft.Json;

namespace WWB.Weixin.Work.Apis.Auth.Dtos
{
    public class GetUserResponse : ApiResultBase
    {
        /// <summary>
        /// 当用户为企业成员时.成员UserID
        /// </summary>
        [JsonProperty("userid")]
        public string UserId { get; set; }

        /// <summary>
        /// 当用户为企业成员时.成员票据
        /// </summary>
        [JsonProperty("user_ticket")]
        public string UserTicket { get; set; }

        /// <summary>
        /// 当用户为学校的家长时.家长的外部联系人id
        /// </summary>
        [JsonProperty("external_userid")]
        public string ExternalUserid { get; set; }

        /// <summary>
        /// 当用户为学校的家长时.家校通讯录里家长的userid
        /// </summary>
        [JsonProperty("parent_userid")]
        public string ParentUserid { get; set; }

        /// <summary>
        ///  非企业成员或学生家长授权时.非企业成员的标识，对当前企业唯一
        /// </summary>
        [JsonProperty("openid")]
        public string OpenId { get; set; }
    }
}