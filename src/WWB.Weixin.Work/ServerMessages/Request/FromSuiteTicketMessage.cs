using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace WWB.Weixin.Work.ServerMessages.Request
{
    [XmlRoot("xml")]
    [Serializable]
    public class FromSuiteTicketMessage : FromMessageBase
    {
        [XmlElement("SuiteId")]
        public string SuiteId { get; set; }

        [XmlElement("InfoType")]
        public string InfoType { get; set; }

        [XmlElement("TimeStamp")]
        public string TimeStamp { get; set; }

        [XmlElement("SuiteTicket")]
        public string SuiteTicket { get; set; }
    }
}