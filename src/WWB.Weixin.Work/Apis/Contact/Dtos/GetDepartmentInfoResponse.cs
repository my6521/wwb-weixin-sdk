using Newtonsoft.Json;
using WWB.Weixin.Work.Models;

namespace WWB.Weixin.Work.Apis.Contact.Dtos
{
    public class GetDepartmentInfoResponse : ApiResultBase
    {
        [JsonProperty("department")]
        public DepartmentInfo department { get; set; }
    }
}