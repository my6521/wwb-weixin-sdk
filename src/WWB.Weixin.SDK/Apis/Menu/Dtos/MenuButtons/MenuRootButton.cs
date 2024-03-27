using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WWB.Weixin.SDK.Apis.Menu
{
    public class MenuRootButton : MenuButtonBase
    {
        [JsonProperty("sub_button")]
        public List<MenuButtonBase> SubButton { get; set; }
    }
}
