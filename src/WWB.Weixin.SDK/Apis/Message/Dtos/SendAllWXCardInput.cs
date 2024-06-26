﻿using Newtonsoft.Json;

namespace WWB.Weixin.SDK.Apis.Message
{
    /// <summary>
    /// Defines the <see cref="SendAllWXCardInput" />
    /// </summary>
    public class SendAllWXCardInput : SendAllInputBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SendAllWXCardInput"/> class.
        /// </summary>
        public SendAllWXCardInput()
        {
            MessageType = MessageTypes.wxcard;
        }

        /// <summary>
        /// Gets or sets the WXCard
        /// </summary>
        [JsonProperty("wxcard")]
        public WXCardInfo WXCard { get; set; }

        /// <summary>
        /// Defines the <see cref="WXCardInfo" />
        /// </summary>
        public class WXCardInfo
        {
            /// <summary>
            /// Gets or sets the MediaId
            /// </summary>
            [JsonProperty("media_id")]
            public string MediaId { get; set; }
        }
    }
}