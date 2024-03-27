using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiClientCore.Attributes;

namespace WWB.Weixin.Work.Apis
{
    [HttpHost("https://qyapi.weixin.qq.com")]
    [JsonNetReturn(EnsureMatchAcceptContentType = false)]
    public interface IBaseHttpApi
    {
    }
}