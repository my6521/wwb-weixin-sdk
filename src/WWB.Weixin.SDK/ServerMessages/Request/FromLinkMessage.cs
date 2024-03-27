namespace WWB.Weixin.SDK.ServerMessages.Request
{
    /// <summary>
    /// 链接消息
    /// </summary>
    public class FromLinkMessage : FromMessageBase
    {
        /// <summary>
        /// Gets or sets the Title
        /// 消息标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the Description
        /// 消息描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the Url
        /// 消息链接
        /// </summary>
        public string Url { get; set; }
    }
}