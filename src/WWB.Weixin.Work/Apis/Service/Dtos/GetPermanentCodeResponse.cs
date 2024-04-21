using Newtonsoft.Json;
using System.Collections.Generic;
using WWB.Weixin.Work.Models;

namespace WWB.Weixin.Work.Apis.Service.Dtos
{
    public class GetPermanentCodeResponse : ApiResultBase
    {
        /// <summary>
        /// 企业微信永久授权码,最长为512字节
        /// </summary>
        [JsonProperty("permanent_code")]
        public string PermanentCode { get; set; }

        /// <summary>
        /// 授权方企业信息
        /// </summary>
        [JsonProperty("auth_corp_info")]
        public AuthCorpInfo AuthCorpInfo { get; set; }

        /// <summary>
        /// 安装应用时，扫码或者授权链接中带的state值。详见state说明
        /// </summary>
        [JsonProperty("state")]
        public string State { get; set; }

        public AuthInfo auth_info { get; set; }

        public class AuthInfo
        {
            public List<AgentInfo> agent { get; set; }
        }

        public class AgentInfo
        {
            public int agentid { get; set; }
            public string name { get; set; }
        }
    }
}