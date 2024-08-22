using Newtonsoft.Json;
using System.Collections.Generic;

namespace WWB.Weixin.Work.Apis.School.Dtos
{
    public class GetSchoolStudentListResponse : ApiResultBase
    {
        [JsonProperty("students")]
        public List<SchoolStudentInfo> students { get; set; }
    }
}