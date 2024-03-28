using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WWB.Weixin.Work
{
    /// <summary>
    /// 凭据管理
    /// </summary>
    public interface ITokenManager
    {
        /// <summary>
        /// 获取服务商凭据
        /// </summary>
        /// <returns></returns>
        Task<string> GetProviderAccessToken();

        /// <summary>
        /// 获取应用凭据
        /// </summary>
        /// <returns></returns>
        Task<string> GetSuiteAccessToken();

        /// <summary>
        /// 获取企业授权凭据
        /// </summary>
        /// <param name="corpId"></param>
        /// <param name="corpsecret"></param>
        /// <returns></returns>
        Task<string> GetAccessToken(string corpId, string corpsecret);
    }
}