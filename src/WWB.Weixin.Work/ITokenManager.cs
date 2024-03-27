using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WWB.Weixin.Work
{
    public interface ITokenManager
    {
        Task<string> GetProviderToken();

        Task<string> GetSuiteToken();

        Task<string> GetToken(string corpId, string corpsecret);
    }
}