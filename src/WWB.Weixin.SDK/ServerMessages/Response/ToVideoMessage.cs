namespace WWB.Weixin.SDK.ServerMessages.Response
{
    using System;
    using System.Xml.Serialization;

    /// <summary>
    /// 回复视频消息
    /// </summary>
    [XmlRoot(ElementName = "xml")]
    public class ToVideoMessage : ToMessageBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ToVideoMessage"/> class.
        /// </summary>
        public ToVideoMessage()
        {
            Type = ToMessageTypes.video;
        }

        /// <summary>
        /// Gets or sets the Voice
        /// </summary>
        public VideoInfo Voice { get; set; }

        /// <summary>
        /// Defines the <see cref="VideoInfo" />
        /// </summary>
        [Serializable]
        public class VideoInfo
        {
            /// <summary>
            /// Gets or sets the MediaId
            /// </summary>
            public string MediaId { get; set; }

            /// <summary>
            /// Gets or sets the Title
            /// 视频消息的标题
            /// </summary>
            public string Title { get; set; }

            /// <summary>
            /// Gets or sets the Description
            /// 视频消息的描述
            /// </summary>
            public string Description { get; set; }
        }
    }
}