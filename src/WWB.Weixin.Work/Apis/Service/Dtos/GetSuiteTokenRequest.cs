using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WWB.Weixin.Work.Apis.Service.Dtos
{
    public class GetSuiteTokenRequest
    {
        [JsonProperty("suite_id")]
        [Required]
        public string SuiteId { get; set; }

        [JsonProperty("suite_secret")]
        [Required]
        public string SuiteSecret { get; set; }

        [JsonProperty("suite_ticket")]
        [Required]
        public string SuiteTicket { get; set; }
    }
}