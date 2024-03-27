using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WWB.Weixin.Work.Apis.Auth.Dtos
{
    public class GetUserResponse : BaseResponse
    {
        [JsonProperty("userid")]
        public string UserId { get; set; }

        [JsonProperty("user_ticket")]
        public string UserTicket { get; set; }
    }
}