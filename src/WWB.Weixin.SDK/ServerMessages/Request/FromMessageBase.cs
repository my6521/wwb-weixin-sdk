namespace WWB.Weixin.SDK.ServerMessages.Request
{
    using System;
    using System.Xml.Serialization;
    using WWB.Weixin.Utility;

    /// <summary>
    /// Defines the <see cref="FromMessageBase" />
    /// </summary>
    [XmlRoot("xml")]
    [Serializable]
    public abstract class FromMessageBase : IFromMessage
    {
        /// <summary>
        /// Gets or sets the ToUserName
        /// 开发者微信号
        /// </summary>
        [XmlElement("ToUserName")]
        public string ToUserName { get; set; }

        /// <summary>
        /// Gets or sets the FromUserName
        /// 发送方帐号（一个OpenID）
        /// </summary>
        [XmlElement("FromUserName")]
        public string FromUserName { get; set; }

        /// <summary>
        /// Gets or sets the CreateTimestamp
        /// </summary>
        [XmlElement("CreateTime")]
        internal long CreateTimestamp { get; set; }

        /// <summary>
        /// Gets the CreateDateTime
        /// 创建时间
        /// </summary>
        [XmlIgnore]
        public DateTime CreateDateTime => CreateTimestamp > 0 ? CreateTimestamp.ConvertToDateTime() : default;

        /// <summary>
        /// Gets or sets the Type
        /// 消息类型
        /// </summary>
        [XmlElement("MsgType")]
        public FromMessageTypes Type { get; set; }

        /// <summary>
        /// Gets or sets the MessageId
        /// 消息id，64位整型
        /// </summary>
        [XmlElement("MsgId")]
        public string MessageId { get; set; }
    }
}