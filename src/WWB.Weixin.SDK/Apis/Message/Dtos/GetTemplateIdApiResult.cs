using Newtonsoft.Json;

namespace WWB.Weixin.SDK.Apis.Message
{
    public class GetTemplateIdApiResult : ApiResultBase
    {
        /// <summary>
        /// 模板ID
        /// </summary>
        [JsonProperty("template_id")]
        public string TemplateId { get; set; }


    }
}