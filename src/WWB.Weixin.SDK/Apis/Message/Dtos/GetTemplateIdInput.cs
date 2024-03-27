using Newtonsoft.Json;

namespace WWB.Weixin.SDK.Apis.Message
{
    public class GetTemplateIdInput
    {
        /// <summary>
        /// 模板库中模板的编号，有“TM**”和“OPENTMTM**”等形式
        /// </summary>
        [JsonProperty("template_id_short")]
        public string TemplateIdShort { get; set; }
    }
}