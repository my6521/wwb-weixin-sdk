namespace WWB.Weixin.Work.Apis.School.Dtos
{
    public class GetSchoolStudentInfoResponse : ApiResultBase
    {
        public int user_type { get; set; }

        public SchoolStudentInfo student { get; set; }
        public SchoolParentInfo parent { get; set; }
    }
}