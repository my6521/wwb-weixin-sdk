using Newtonsoft.Json;
using System.Collections.Generic;

namespace WWB.Weixin.Work.Apis.School.Dtos
{
    public class GetSchoolDepartmentListResponse : ApiResultBase
    {
        [JsonProperty("departments")]
        public List<SchoolDepartmentInfo> departments { get; set; }
    }
}