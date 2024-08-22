namespace WWB.Weixin.Work.Apis.School.Dtos
{
    public class GetSchoolUserInfoResponse : ApiResultBase
    {
        public string DeviceId { get; set; }
        public string parent_userid { get; set; }
        public string student_userid { get; set; }
    }
}