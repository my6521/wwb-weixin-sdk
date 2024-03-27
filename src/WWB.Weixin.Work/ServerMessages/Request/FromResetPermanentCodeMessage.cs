using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace WWB.Weixin.Work.ServerMessages.Request
{
    [XmlRoot("xml")]
    [Serializable]
    public class FromResetPermanentCodeMessage : FromMessageBase
    {
        [XmlElement("SuiteId")]
        public string SuiteId { get; set; }

        [XmlElement("AuthCode")]
        public string AuthCode { get; set; }

        [XmlElement("InfoType")]
        public string InfoType { get; set; }

        [XmlElement("TimeStamp")]
        public string TimeStamp { get; set; }
    }
}