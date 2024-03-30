using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace WWB.Weixin.Work.ServerMessages.Request
{
    [XmlRoot("xml")]
    [Serializable]
    public class FromCreatePartyMessage : FromMessageBase
    {
        [XmlElement("ToUserName")]
        public string ToUserName { get; set; }

        [XmlElement("FromUserName")]
        public string FromUserName { get; set; }

        [XmlElement("Id")]
        public int Id { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("ParentId")]
        public int ParentId { get; set; }

        [XmlElement("Order")]
        public int Order { get; set; }
    }
}