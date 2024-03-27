namespace WWB.Weixin.SDK.ServerMessages.Request.Events
{
    using System;
    using System.Xml.Serialization;
    using WWB.Weixin.SDK.ServerMessages.Request;
    using WWB.Weixin.Utility;

    /// <summary>
    /// Defines the <see cref="FromEventBase" />
    /// </summary>
    [XmlRoot("xml")]
    [Serializable]
    public abstract class FromEventBase : IFromMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FromEventBase"/> class.
        /// </summary>
        protected FromEventBase()
        {
            Type = "event";
        }

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
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the Event
        /// 事件类型，subscribe(订阅)、unsubscribe(取消订阅)
        /// </summary>
        public FromEventTypes Event { get; set; }
    }
}