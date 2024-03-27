namespace WWB.Weixin.SDK.ServerMessages.Request
{
    using System.Xml.Serialization;

    /// <summary>
    /// 地理位置消息
    /// </summary>
    public class FromLocationMessage : FromMessageBase
    {
        /// <summary>
        /// Gets or sets the X
        /// 地理位置维度
        /// </summary>
        [XmlElement("Location_X")]
        public double X { get; set; }

        /// <summary>
        /// Gets or sets the Y
        /// 地理位置经度
        /// </summary>
        [XmlElement("Location_Y")]
        public double Y { get; set; }

        /// <summary>
        /// Gets or sets the Scale
        /// 地图缩放大小
        /// </summary>
        public double Scale { get; set; }

        /// <summary>
        /// Gets or sets the Label
        /// 地理位置信息
        /// </summary>
        public string Label { get; set; }
    }
}