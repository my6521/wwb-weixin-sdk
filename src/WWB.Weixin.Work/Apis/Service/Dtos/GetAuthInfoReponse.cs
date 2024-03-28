using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WWB.Weixin.Work.Models;

namespace WWB.Weixin.Work.Apis.Service.Dtos
{
    public class GetAuthInfoReponse : ApiResultBase
    {
        [JsonProperty("auth_corp_info")]
        public AuthCorpInfo AuthCorpInfo { get; set; }
    }
}