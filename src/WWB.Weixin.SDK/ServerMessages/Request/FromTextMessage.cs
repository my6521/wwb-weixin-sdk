namespace WWB.Weixin.SDK.ServerMessages.Request
{
    using System;
    using System.Xml.Serialization;

    /// <summary>
    /// �����ı���Ϣ
    /// </summary>
    [XmlRoot("xml")]
    [Serializable]
    public class FromTextMessage : FromMessageBase
    {
        /// <summary>
        /// Gets or sets the Content
        /// �ı���Ϣ����
        /// </summary>
        public string Content { get; set; }
    }
}