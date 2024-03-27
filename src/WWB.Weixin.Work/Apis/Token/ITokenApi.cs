using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiClientCore.Attributes;
using WWB.Weixin.Work.Apis.Token.Dtos;

namespace WWB.Weixin.Work.Apis.Token
{
    /// <summary>
    /// 授权相关
    /// </summary>
    public interface ITokenApi : IBaseHttpApi
    {
        /// <summary>
        /// 获取access_token
        /// </summary>
        /// <param name="corpid"></param>
        /// <param name="corpsecret"></param>
        /// <returns></returns>
        [HttpGet("/cgi-bin/gettoken")]
        Task<GetTokenResponse> GetToken([PathQuery] string corpid, [PathQuery] string corpsecret);
    }
}