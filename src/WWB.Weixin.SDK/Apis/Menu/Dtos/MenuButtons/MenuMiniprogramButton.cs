using System.ComponentModel.DataAnnotations;

namespace WWB.Weixin.SDK.Apis.Menu
{
    public class MenuMiniprogramButton : SubMenuButtonBase
    {
        public MenuMiniprogramButton()
        {
            Type = MenuButtonTypes.miniprogram;
        }

        [Required]
        [StringLength(256)]
        public string Url { get; set; }

        public string AppId { get; set; }
        public string PagePath { get; set; }
    }
}
