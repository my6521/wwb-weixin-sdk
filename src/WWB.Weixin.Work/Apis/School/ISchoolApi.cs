using System.Threading.Tasks;
using WebApiClientCore.Attributes;
using WWB.Weixin.Work.Apis.School.Dtos;

namespace WWB.Weixin.Work.Apis.School
{
    public interface ISchoolApi : IBaseHttpApi
    {
        /// <summary>
        /// 获取部门列表
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/cgi-bin/school/department/list")]
        Task<GetSchoolDepartmentListResponse> GetDepartmentList([PathQuery] string access_token, [PathQuery] string id);

        /// <summary>
        /// 获取部门家长详情
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="department_id"></param>
        /// <returns></returns>
        [HttpGet("/cgi-bin/school/user/list_parent")]
        Task<GetSchoolParentListResponse> GetParentList([PathQuery] string access_token, [PathQuery] string department_id);

        /// <summary>
        /// 获取部门学生详情
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="department_id"></param>
        /// <returns></returns>
        [HttpGet("/cgi-bin/school/user/list")]
        Task<GetSchoolStudentListResponse> GetStudentList([PathQuery] string access_token, [PathQuery] string department_id);

        /// <summary>
        /// 读取学生或家长
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        [HttpGet("/cgi-bin/school/user/get")]
        Task<GetSchoolParentOrStudentInfoResponse> GetParentOrStudentInfo([PathQuery] string access_token, [PathQuery] string userid);

        /// <summary>
        /// 获取家校访问用户身份
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet("/cgi-bin/school/getuserinfo")]
        Task<GetSchoolUserInfoResponse> GetUserInfo([PathQuery] string access_token, [PathQuery] string code);

        /// <summary>
        /// 发送学校通知
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("/cgi-bin/externalcontact/message/send")]
        Task<SendSchoolMessageResponse> SendMessage([PathQuery] string access_token, [JsonNetContent] SendSchoolMessageBase request);
    }
}