namespace WWB.Weixin.SDK.ServerMessages.Request.Events
{
    using System.Xml.Serialization;
    using WWB.Weixin.SDK.ServerMessages.Request;

    /// <summary>
    /// 上报地理位置事件
    /// </summary>
    [XmlRoot("xml")]
    public class FromLocationEvent : FromEventBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FromLocationEvent"/> class.
        /// </summary>
        public FromLocationEvent()
        {
            Event = FromEventTypes.location;
        }

        /// <summary>
        /// Gets or sets the Latitude
        /// 地理位置纬度
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Gets or sets the Longitude
        /// 地理位置经度
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// Gets or sets the Precision
        /// 地理位置精度
        /// </summary>
        public double Precision { get; set; }
    }
}