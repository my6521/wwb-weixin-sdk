using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WWB.Weixin.Work.Models
{
    public class AuthCorpInfo
    {
        /// <summary>
        /// 授权方企业微信id
        /// </summary>
        [JsonProperty("corpid")]
        public string CorpId { get; set; }

        /// <summary>
        /// 授权方企业名称，即企业简称
        /// </summary>
        [JsonProperty("corp_name")]
        public string CorpName { get; set; }

        /// <summary>
        /// 授权方企业类型，认证号：verified, 注册号：unverified
        /// </summary>
        [JsonProperty("corp_type")]
        public string CorpType { get; set; }

        /// <summary>
        /// 授权方企业方形头像
        /// </summary>
        [JsonProperty("corp_square_logo_url")]
        public string CorpSquareLogoUrl { get; set; }

        /// <summary>
        /// 授权方企业用户规模
        /// </summary>
        [JsonProperty("corp_user_max")]
        public int CorpUserMax { get; set; }

        /// <summary>
        /// 授权方企业的主体名称(仅认证或验证过的企业有)，即企业全称。企业微信将逐步回收该字段，后续实际返回内容为企业名称，即auth_corp_info.corp_name。
        /// </summary>
        [JsonProperty("corp_full_name")]
        public string CorpFullName { get; set; }

        /// <summary>
        /// 企业类型，1. 企业; 2. 政府以及事业单位; 3. 其他组织, 4.团队号
        /// </summary>
        [JsonProperty("subject_type")]
        public int SubjectType { get; set; }

        /// <summary>
        /// 授权企业在微信插件（原企业号）的二维码，可用于关注微信插件
        /// </summary>
        [JsonProperty("corp_wxqrcode")]
        public string CorpWxqrcode { get; set; }

        /// <summary>
        /// 企业规模。当企业未设置该属性时，值为空
        /// </summary>
        [JsonProperty("corp_scale")]
        public string CorpScale { get; set; }

        /// <summary>
        /// 企业所属行业。当企业未设置该属性时，值为空
        /// </summary>
        [JsonProperty("corp_industry")]
        public string CorpIndustry { get; set; }

        /// <summary>
        /// 企业所属子行业。当企业未设置该属性时，值为空
        /// </summary>
        [JsonProperty("corp_sub_industry")]
        public string CorpSubIndustry { get; set; }
    }
}