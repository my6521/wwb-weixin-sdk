using System.Threading.Tasks;
using WebApiClientCore.Attributes;
using WWB.Weixin.Work.Apis.School.Dtos;

namespace WWB.Weixin.Work.Apis.School
{
    public interface ISchoolApi : IBaseHttpApi
    {
        [HttpGet("/cgi-bin/school/department/list")]
        Task<GetSchoolDepartmentListResponse> GetDepartmentList([PathQuery] string access_token, [PathQuery] string id);

        [HttpGet("/cgi-bin/school/user/list_parent")]
        Task<GetSchoolParentListResponse> GetParentList([PathQuery] string access_token, [PathQuery] string department_id);

        [HttpGet("/cgi-bin/school/user/list")]
        Task<GetSchoolStudentListResponse> GetStudentList([PathQuery] string access_token, [PathQuery] string department_id);

        [HttpGet("/cgi-bin/school/user/get")]
        Task<GetSchoolStudentInfoResponse> GetStudentInfo([PathQuery] string access_token, [PathQuery] string userid);

        [HttpGet("/cgi-bin/school/getuserinfo")]
        Task<GetSchoolUserInfoResponse> GetUserInfo([PathQuery] string access_token, [PathQuery] string code);

        [HttpGet("/cgi-bin/externalcontact/message/send")]
        Task<SendSchoolMessageResponse> SendMessage([PathQuery] string access_token, [JsonNetContent] SendSchoolMessageBase request);
    }
}