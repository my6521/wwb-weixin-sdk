using Newtonsoft.Json;

namespace WWB.Weixin.SDK.Apis.Menu
{
    public class GetMenuApiResult : ApiResultBase
    {
        [JsonProperty("menu")]
        public MenuInfo Menu { get; set; }
    }
}
