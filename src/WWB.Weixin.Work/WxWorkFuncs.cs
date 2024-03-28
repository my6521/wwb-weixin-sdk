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
        public Func<WxWorkOptions> GetWxWorkOptions { get; set; }
        public Func<string, string> GetProviderToken { get; set; }
        public Func<string, string> GetSuiteToken { get; set; }
        public Func<string, string, string> GetAccessToken { get; set; }
        public Action<string, string> CacheProviderToken { get; set; }
        public Action<string, string, string> CacheAccessToken { get; set; }
        public Action<string, string> CacheSuiteToken { get; set; }

        public Func<string, Task<string>> GetSuiteTicket { get; set; }
        public Func<string, string, Task<string>> GetPermanentCode { get; set; }
    }
}