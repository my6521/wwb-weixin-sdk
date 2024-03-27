using Newtonsoft.Json;
using System.Collections.Generic;

namespace WWB.Weixin.SDK.Apis.Menu
{
    public class CreateMenuInput
    {
        [JsonProperty("button")]
        public List<MenuButtonBase> Button { get; set; }
    }
}
