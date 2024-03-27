namespace WWB.Weixin.SDK.ServerMessages.Request.Events
{
    using System.Xml.Serialization;
    using WWB.Weixin.SDK.ServerMessages.Request;

    /// <summary>
    /// 点击菜单跳转小程序的事件推送
    /// </summary>
    [XmlRoot("xml")]
    public class FromViewMiniprogramEvent : FromEventBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FromViewEvent"/> class.
        /// </summary>
        public FromViewMiniprogramEvent()
        {
            Event = FromEventTypes.view_miniprogram;
        }

        /// <summary>
        /// 事件KEY值，跳转的小程序路径
        /// </summary>
        public string EventKey { get; set; }

        /// <summary>
        /// 菜单ID，如果是个性化菜单，则可以通过这个字段，知道是哪个规则的菜单被点击了
        /// </summary>
        public string MenuId { get; set; }
    }
}