using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WWB.Weixin.Work.Models
{
    public class TokenResult
    {
        public TokenResult(string accessToken, int expiresIn)
        {
            AccessToken = accessToken;
            ExpiresIn = expiresIn;
        }

        public string AccessToken { get; set; }
        public int ExpiresIn { get; set; }
    }
}