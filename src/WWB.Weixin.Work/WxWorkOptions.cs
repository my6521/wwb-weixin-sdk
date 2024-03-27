using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WWB.Weixin.Work
{
    public class WxWorkOptions
    {
        public string CorpId { get; set; }
        public string ProviderSecret { get; set; }
        public string PushToken { get; set; }
        public string PushEncodingAESKey { get; set; }
        public string SuiteId { get; set; }
        public string SuiteSecret { get; set; }
    }
}