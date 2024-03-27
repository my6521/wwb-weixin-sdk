namespace WWB.Weixin.SDK.ServerMessages.Request
{
    using System;
    using System.Xml.Serialization;

    /// <summary>
    /// 接收文本消息
    /// </summary>
    [XmlRoot("xml")]
    [Serializable]
    public class FromTextMessage : FromMessageBase
    {
        /// <summary>
        /// Gets or sets the Content
        /// 文本消息内容
        /// </summary>
        public string Content { get; set; }
    }
}