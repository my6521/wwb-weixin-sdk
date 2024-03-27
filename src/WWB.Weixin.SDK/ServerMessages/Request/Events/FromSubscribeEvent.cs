namespace WWB.Weixin.SDK.ServerMessages.Request.Events
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using WWB.Weixin.SDK.ServerMessages.Request;

    /// <summary>
    /// 关注事件
    /// </summary>
    [XmlRoot("xml")]
    public class FromSubscribeEvent : FromEventBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FromSubscribeEvent"/> class.
        /// </summary>
        public FromSubscribeEvent()
        {
            Event = FromEventTypes.subscribe;
        }

        /// <summary>
        /// Gets or sets the EventKey
        /// 事件KEY值，qrscene_为前缀，后面为二维码的参数值
        /// </summary>
        public string EventKey { get; set; }

        /// <summary>
        /// Gets the Data
        /// 事件字典值
        /// </summary>
        [XmlIgnore]
        public Dictionary<string, string> Data
        {
            get
            {
                if (string.IsNullOrWhiteSpace(EventKey))
                {
                    return null;
                }
                return EventKey.StartsWith("{") ? JsonConvert.DeserializeObject<Dictionary<string, string>>(EventKey) : null;
            }
        }

        /// <summary>
        /// Gets or sets the Ticket
        /// 二维码的ticket，可用来换取二维码图片
        /// </summary>
        public string Ticket { get; set; }
    }
}