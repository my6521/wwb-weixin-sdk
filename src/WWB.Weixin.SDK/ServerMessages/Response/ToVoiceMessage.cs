namespace WWB.Weixin.SDK.ServerMessages.Response
{
    using System;
    using System.Xml.Serialization;

    /// <summary>
    /// ªÿ∏¥”Ô“Ùœ˚œ¢
    /// </summary>
    [XmlRoot(ElementName = "xml")]
    public class ToVoiceMessage : ToMessageBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ToVoiceMessage"/> class.
        /// </summary>
        public ToVoiceMessage()
        {
            Type = ToMessageTypes.voice;
        }

        /// <summary>
        /// Gets or sets the Voice
        /// </summary>
        public VoiceInfo Voice { get; set; }

        /// <summary>
        /// Defines the <see cref="VoiceInfo" />
        /// </summary>
        [Serializable]
        public class VoiceInfo
        {
            /// <summary>
            /// Gets or sets the MediaId
            /// </summary>
            public string MediaId { get; set; }
        }
    }
}