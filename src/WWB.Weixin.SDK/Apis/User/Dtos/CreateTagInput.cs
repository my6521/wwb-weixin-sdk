using Newtonsoft.Json;

namespace WWB.Weixin.SDK.Apis.User.Dtos
{
    public class CreateTagInput
    {
        [JsonProperty("tag")]
        public CreateTagModel Tag { get; set; }
    }

    public class CreateTagModel
    {
        /// <summary>
        /// 标签名（30个字符以内）
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}