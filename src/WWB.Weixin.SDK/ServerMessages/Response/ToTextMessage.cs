namespace WWB.Weixin.SDK.ServerMessages.Response
{
    using System.Xml.Serialization;

    /// <summary>
    /// 回复文本消息
    /// </summary>
    [XmlRoot(ElementName = "xml")]
    public class ToTextMessage : ToMessageBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ToTextMessage"/> class.
        /// </summary>
        public ToTextMessage()
        {
            Type = ToMessageTypes.text;
        }

        /// <summary>
        /// Gets or sets the Content
        /// 文本消息内容
        /// </summary>
        public string Content { get; set; }
    }
}