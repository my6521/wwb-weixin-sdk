using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WWB.Weixin.Work.Apis.Contact.Dtos
{
    public class GetUserIdResponse : BaseResponse
    {
        [JsonProperty("userid")]
        public string UserId { get; set; }
    }
}