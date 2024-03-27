﻿namespace WWB.Weixin.SDK.ServerMessages.Request
{
    using System.Xml.Serialization;

    /// <summary>
    /// 语音消息
    /// </summary>
    public class FromVoiceMessage : FromMessageBase
    {
        /// <summary>
        /// Gets or sets the Format
        /// 语音格式，如amr，speex等
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// Gets or sets the MediaId
        /// 语音消息媒体id，可以调用多媒体文件下载接口拉取数据。
        /// </summary>
        [XmlElement("MediaId")]
        public string MediaId { get; set; }

        /// <summary>
        /// Gets or sets the Recognition
        /// 语音识别结果（仅启用了语音识别之后才返回）
        /// </summary>
        [XmlElement("Recognition")]
        public string Recognition { get; set; }
    }
}