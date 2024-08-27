namespace WWB.Weixin.Work.Apis.School.Dtos
{
    public class GetSchoolParentOrStudentInfoResponse : ApiResultBase
    {
        /// <summary>
        /// 用户类型:1表示学生，2表示家长
        /// </summary>
        public int user_type { get; set; }

        /// <summary>
        /// 学生信息
        /// </summary>
        public SchoolStudentInfo student { get; set; }

        /// <summary>
        /// 家长信息
        /// </summary>
        public SchoolParentInfo parent { get; set; }
    }
}