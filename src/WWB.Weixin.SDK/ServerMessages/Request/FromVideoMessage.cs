﻿namespace WWB.Weixin.SDK.ServerMessages.Request
{
    using System.Xml.Serialization;

    /// <summary>
    /// 视频消息
    /// </summary>
    public class FromVideoMessage : FromMessageBase
    {
        /// <summary>
        /// Gets or sets the ThumbMediaId
        /// 视频消息缩略图的媒体id，可以调用多媒体文件下载接口拉取数据。
        /// </summary>
        public string ThumbMediaId { get; set; }

        /// <summary>
        /// Gets or sets the MediaId
        /// 语音消息媒体id，可以调用多媒体文件下载接口拉取数据。
        /// </summary>
        [XmlElement("MediaId")]
        public string MediaId { get; set; }
    }
}