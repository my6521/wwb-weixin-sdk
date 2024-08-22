using System.Collections.Generic;

namespace WWB.Weixin.Work.Apis.School.Dtos
{
    public class SendSchoolMessageResponse : ApiResultBase
    {
        public List<string> invalid_parent_userid { get; set; }
        public List<string> invalid_student_userid { get; set; }
        public List<string> invalid_party { get; set; }
    }
}