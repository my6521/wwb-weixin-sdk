using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace WWB.Weixin.SDK.Apis.Menu
{
    public class MenuViewButton : SubMenuButtonBase
    {
        public MenuViewButton()
        {
            Type = MenuButtonTypes.view;
        }

        /// <summary>
        /// 网页链接，用户点击菜单可打开链接，不超过256字节
        /// </summary>
        [Required]
        [StringLength(256)]
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
