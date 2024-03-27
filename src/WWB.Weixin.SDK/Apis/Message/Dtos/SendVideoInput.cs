using Newtonsoft.Json;

namespace WWB.Weixin.SDK.Apis.Message
{
    public class SendVideoInput : SendInputBase
    {
        public SendVideoInput()
        {
            MessageType = MessageTypes.video;
        }

        [JsonProperty("video")]
        public VideoInfo Video { get; set; }

        public class VideoInfo
        {
            [JsonProperty("media_id")]
            public string MediaId { get; set; }
        }
    }
}