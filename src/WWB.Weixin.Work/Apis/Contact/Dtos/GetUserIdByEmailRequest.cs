using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WWB.Weixin.Work.Apis.Contact.Dtos
{
    public class GetUserIdByEmailRequest
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("email_type")]
        public int EmailType { get; set; }
    }
}