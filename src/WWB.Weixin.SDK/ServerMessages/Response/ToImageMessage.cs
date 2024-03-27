namespace WWB.Weixin.SDK.ServerMessages.Response
{
    using System;
    using System.Xml.Serialization;

    /// <summary>
    /// 回复图片消息
    /// </summary>
    [XmlRoot(ElementName = "xml")]
    public class ToImageMessage : ToMessageBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ToImageMessage"/> class.
        /// </summary>
        public ToImageMessage()
        {
            Type = ToMessageTypes.image;
        }

        /// <summary>
        /// Gets or sets the Image
        /// </summary>
        public ImageInfo Image { get; set; }

        /// <summary>
        /// Defines the <see cref="ImageInfo" />
        /// </summary>
        [Serializable]
        public class ImageInfo
        {
            /// <summary>
            /// Gets or sets the MediaId
            /// </summary>
            public string MediaId { get; set; }
        }
    }
}