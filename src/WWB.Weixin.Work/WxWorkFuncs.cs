using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WWB.Weixin.Work
{
    public class WxWorkFuncs
    {
        public Func<WxWorkOptions> GetWxWorkOptions { get; set; }
        public Func<string, Task<string>> GetSuiteTicket { get; set; }
        public Func<string, string, Task<string>> GetPermanentCode { get; set; }
    }
}