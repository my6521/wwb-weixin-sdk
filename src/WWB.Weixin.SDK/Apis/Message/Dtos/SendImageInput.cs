using Newtonsoft.Json;
using System.Collections.Generic;

namespace WWB.Weixin.SDK.Apis.Message
{
    public class SendImageInput : SendInputBase
    {
        public SendImageInput()
        {
            MessageType = MessageTypes.image;
        }

        [JsonProperty("image")]
        public ImageInfo Image { get; set; }

        public class ImageInfo
        {
            [JsonProperty("media_ids")]
            public List<string> MediaIds { get; set; }

            /// <summary>
            /// 推荐语，不填则默认为“分享图片”
            /// </summary>
            public string recommend { get; set; }

            public int need_open_comment { get; set; }
            public int only_fans_can_comment { get; set; }
        }
    }
}