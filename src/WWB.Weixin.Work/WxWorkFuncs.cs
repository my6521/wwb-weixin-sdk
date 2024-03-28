using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WWB.Weixin.Work
{
    /// <summary>
    ///
    /// </summary>
    public class WxWorkFuncs
    {
        /// <summary>
        /// 获取企业微信配置
        /// </summary>
        public Func<WxWorkOptions> GetWxWorkOptions { get; set; }

        /// <summary>
        /// 获取服务商授权凭据
        /// </summary>
        public Func<string, string> GetProviderAccessToken { get; set; }

        /// <summary>
        /// 获取应用授权凭据
        /// </summary>
        public Func<string, string> GetSuiteAccessToken { get; set; }

        /// <summary>
        /// 获取企业授权凭据
        /// </summary>
        public Func<string, string, string> GetAccessToken { get; set; }

        /// <summary>
        /// 缓存服务商凭据
        /// </summary>
        public Action<string, string> CacheProviderAccessToken { get; set; }

        /// <summary>
        /// 缓存应用凭据
        /// </summary>
        public Action<string, string> CacheSuiteAccessToken { get; set; }

        /// <summary>
        /// 缓存企业授权凭据
        /// </summary>
        public Action<string, string, string> CacheAccessToken { get; set; }

        /// <summary>
        /// 获取应用票据
        /// </summary>
        public Func<string, Task<string>> GetSuiteTicket { get; set; }

        /// <summary>
        /// 获取应用永久授权嘛
        /// </summary>
        public Func<string, string, Task<string>> GetPermanentCode { get; set; }
    }
}