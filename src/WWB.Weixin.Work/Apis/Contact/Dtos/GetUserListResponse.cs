using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WWB.Weixin.Work.Models;

namespace WWB.Weixin.Work.Apis.Contact.Dtos
{
    public class GetUserListResponse : BaseResponse
    {
        [JsonProperty("userlist")]
        public List<UserInfo> userlist { get; set; }
    }
}