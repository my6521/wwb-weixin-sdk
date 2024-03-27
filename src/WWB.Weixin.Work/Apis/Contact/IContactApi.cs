using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiClientCore.Attributes;
using WWB.Weixin.Work.Apis.Contact.Dtos;

namespace WWB.Weixin.Work.Apis.Contact
{
    /// <summary>
    /// 通讯录
    /// </summary>
    public interface IContactApi : IBaseHttpApi
    {
        /// <summary>
        /// 获取部门列表
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/cgi-bin/department/list")]
        Task<GetDepartmentListResponse> GetDepartmentList([PathQuery] string access_token);

        /// <summary>
        /// 获取单个部门详情
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/cgi-bin/department/get")]
        Task<GetDepartmentInfoResponse> GetDepartmentInfo([PathQuery] string access_token, [PathQuery] string id);

        /// <summary>
        /// 获取部门成员详情
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="department_id"></param>
        /// <returns></returns>
        [HttpGet("/cgi-bin/user/list")]
        Task<GetUserListResponse> GetUserList([PathQuery] string access_token, [PathQuery] string department_id);

        /// <summary>
        /// 获取部门成员
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="department_id"></param>
        /// <returns></returns>
        [HttpGet("/cgi-bin/user/simplelist")]
        Task<GetUserSimpleListResponse> GetUserSimpleList([PathQuery] string access_token, [PathQuery] string department_id);

        /// <summary>
        /// 读取成员
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        [HttpGet("/cgi-bin/user/get")]
        Task<GetUserInfoResponse> GetUserInfo([PathQuery] string access_token, [PathQuery] string userid);

        /// <summary>
        /// 手机号获取userid
        /// </summary>
        /// <param name="access_token"></param>
        /// <returns></returns>
        [HttpPost("/cgi-bin/user/getuserid")]
        Task<GetUserIdResponse> GetUserIdByMobile([JsonNetContent] GetUserIdByMobileRequest request, [PathQuery] string access_token);

        /// <summary>
        /// 邮箱获取userid
        /// </summary>
        /// <param name="access_token"></param>
        /// <returns></returns>
        [HttpPost("/cgi-bin/user/get_userid_by_email")]
        Task<GetUserIdResponse> GetUserIdByEmail([JsonNetContent] GetUserIdByEmailRequest request, [PathQuery] string access_token);
    }
}