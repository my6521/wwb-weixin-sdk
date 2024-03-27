namespace WWB.Weixin.SDK.ServerMessages.Response
{
    using System;
    using System.Xml.Serialization;

    /// <summary>
    /// Defines the <see cref="ToMessageBase" />
    /// </summary>
    [XmlRoot("xml")]
    [Serializable]
    public abstract class ToMessageBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ToMessageBase"/> class.
        /// </summary>
        protected ToMessageBase()
        {
            CreateDateTime = DateTime.Now;
        }

        /// <summary>
        /// Gets or sets the ToUserName
        /// 接收方帐号（收到的OpenID）
        ///     无需设置
        /// </summary>
        [XmlElement("ToUserName")]
        public string ToUserName { get; set; }

        /// <summary>
        /// Gets or sets the FromUserName
        /// 开发者微信号
        ///     无需设置
        /// </summary>
        [XmlElement("FromUserName")]
        public string FromUserName { get; set; }

        /// <summary>
        /// Gets or sets the CreateTimestamp
        /// </summary>
        [XmlElement("CreateTime")]
        public long CreateTimestamp { get; set; }

        /// <summary>
        /// Gets or sets the CreateDateTime
        /// 创建时间
        ///     无需设置,默认设置为当前时间
        /// </summary>
        [XmlIgnore]
        public DateTime CreateDateTime { get; set; }

        /// <summary>
        /// Gets or sets the Type
        /// 消息类型
        ///     无需设置,根据消息类型自动设置
        /// </summary>
        [XmlElement("MsgType")]
        public ToMessageTypes Type { get; set; }
    }
}