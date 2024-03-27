namespace WWB.Weixin.SDK.ServerMessages.Request
{
    using System.Xml.Serialization;

    /// <summary>
    /// 图片消息
    /// </summary>
    public class FromImageMessage : FromMessageBase
    {
        /// <summary>
        /// Gets or sets the ImageUrl
        /// 图片链接
        /// </summary>
        [XmlElement("PicUrl")]
        public string ImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the MediaId
        /// 图片消息媒体id，可以调用多媒体文件下载接口拉取数据。
        /// </summary>
        [XmlElement("MediaId")]
        public string MediaId { get; set; }
    }
}