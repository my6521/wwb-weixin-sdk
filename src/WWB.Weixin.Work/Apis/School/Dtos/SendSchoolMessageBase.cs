using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace WWB.Weixin.Work.Apis.School.Dtos
{
    public class SendSchoolMessageBase
    {
        protected SendSchoolMessageBase(SchoolMessageTypes msgtype)
        {
            this.msgtype = msgtype;
        }

        public int recv_scope { get; set; }
        public List<string> to_parent_userid { get; set; }
        public List<string> to_student_userid { get; set; }
        public List<string> to_party { get; set; }
        public int toall { get; set; }

        [JsonProperty("msgtype")]
        [JsonConverter(typeof(StringEnumConverter))]
        public SchoolMessageTypes msgtype { get; set; }

        public int? agentid { get; set; }

        [JsonProperty("enable_duplicate_check")]
        public int enable_duplicate_check { get; set; } = 0;

        [JsonProperty("duplicate_check_interval")]
        public int duplicate_check_interval { get; set; } = 1800;
    }
}