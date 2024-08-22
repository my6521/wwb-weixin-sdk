using Newtonsoft.Json;
using System.Collections.Generic;

namespace WWB.Weixin.Work.Apis.School.Dtos
{
    public class GetSchoolParentListResponse : ApiResultBase
    {
        [JsonProperty("parents")]
        public List<SchoolParentInfo> parents { get; set; }
    }
}