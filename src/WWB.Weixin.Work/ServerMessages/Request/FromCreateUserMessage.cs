using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace WWB.Weixin.Work.ServerMessages.Request
{
    [XmlRoot("xml")]
    [Serializable]
    public class FromCreateUserMessage : FromMessageBase
    {
        [XmlElement("ToUserName")]
        public string ToUserName { get; set; }

        [XmlElement("FromUserName")]
        public string FromUserName { get; set; }

        [XmlElement("UserID")]
        public string UserID { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Position")]
        public string Position { get; set; }

        [XmlElement("Mobile")]
        public string Mobile { get; set; }

        [XmlElement("Status")]
        public string Status { get; set; }
    }
}