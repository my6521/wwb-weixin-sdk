namespace WWB.Weixin.SDK.ServerMessages.Response
{
    using System;
    using System.Xml.Serialization;

    /// <summary>
    /// 回复视频消息
    /// </summary>
    [XmlRoot(ElementName = "xml")]
    public class ToMusicMessage : ToMessageBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ToMusicMessage"/> class.
        /// </summary>
        public ToMusicMessage()
        {
            Type = ToMessageTypes.music;
        }

        /// <summary>
        /// Gets or sets the Music
        /// </summary>
        public MusicInfo Music { get; set; }

        /// <summary>
        /// Defines the <see cref="MusicInfo" />
        /// </summary>
        [Serializable]
        public class MusicInfo
        {
            /// <summary>
            /// Gets or sets the MusicUrl
            /// 音乐链接
            /// </summary>
            public string MusicUrl { get; set; }

            /// <summary>
            /// Gets or sets the HQMusicUrl
            /// 高质量音乐链接，WIFI环境优先使用该链接播放音乐
            /// </summary>
            public string HQMusicUrl { get; set; }

            /// <summary>
            /// Gets or sets the ThumbMediaId
            /// 缩略图的媒体id，通过素材管理接口上传多媒体文件，得到的id
            /// </summary>
            public string ThumbMediaId { get; set; }

            /// <summary>
            /// Gets or sets the Title
            /// 音乐标题
            /// </summary>
            public string Title { get; set; }

            /// <summary>
            /// Gets or sets the Description
            /// 音乐描述
            /// </summary>
            public string Description { get; set; }
        }
    }
}