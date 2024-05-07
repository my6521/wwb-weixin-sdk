using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace WWB.Weixin.SDK.Apis.Menu
{
    [JsonConverter(typeof(JsonSubtypes), "type")]
    [JsonSubtypes.KnownSubType(typeof(MenuClickButton), MenuButtonTypes.click)]
    [JsonSubtypes.KnownSubType(typeof(MenuViewButton), MenuButtonTypes.view)]
    [JsonSubtypes.KnownSubType(typeof(MenuMiniprogramButton), MenuButtonTypes.miniprogram)]
    [JsonSubtypes.KnownSubType(typeof(MenuMediaButton), MenuButtonTypes.media_id)]
    [JsonSubtypes.FallBackSubType(typeof(MenuRootButton))]
    public abstract class MenuButtonBase
    {
        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public abstract class SubMenuButtonBase : MenuButtonBase
    {
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public MenuButtonTypes Type { get; set; }
    }
}