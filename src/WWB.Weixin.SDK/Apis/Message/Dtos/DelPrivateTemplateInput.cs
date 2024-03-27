using Newtonsoft.Json;

namespace WWB.Weixin.SDK.Apis.Message
{
    /// <summary>
    /// 删除模板入参
    /// </summary>
    public class DelPrivateTemplateInput
    {

        /// <summary>
        /// 模板ID
        /// </summary>
        [JsonProperty("template_id")]
        public string TemplateId { get; set; }
    }
}