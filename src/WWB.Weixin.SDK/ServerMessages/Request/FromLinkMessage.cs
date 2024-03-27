namespace WWB.Weixin.SDK.ServerMessages.Request
{
    /// <summary>
    /// ������Ϣ
    /// </summary>
    public class FromLinkMessage : FromMessageBase
    {
        /// <summary>
        /// Gets or sets the Title
        /// ��Ϣ����
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the Description
        /// ��Ϣ����
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the Url
        /// ��Ϣ����
        /// </summary>
        public string Url { get; set; }
    }
}