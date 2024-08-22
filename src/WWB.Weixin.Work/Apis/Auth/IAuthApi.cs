using System.Threading.Tasks;
using WebApiClientCore.Attributes;
using WWB.Weixin.Work.Apis.Auth.Dtos;

namespace WWB.Weixin.Work.Apis.Auth
{
    /// <summary>
    /// 身份验证
    /// </summary>
    public interface IAuthApi : IBaseHttpApi
    {
        /// <summary>
        /// 获取访问用户身份
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet("/cgi-bin/auth/getuserinfo")]
        Task<GetUserResponse> GetUserInfo([PathQuery] string access_token, [PathQuery] string code);

        /// <summary>
        /// 获取访问用户敏感信息
        /// </summary>
        /// <param name="request"></param>
        /// <param name="access_token"></param>
        /// <returns></returns>
        [HttpPost("/cgi-bin/auth/getuserdetail")]
        Task<GetUserDetailResponse> GetUserDetail([JsonNetContent] GetUserDetailRequest request, [PathQuery] string access_token);
    }
}