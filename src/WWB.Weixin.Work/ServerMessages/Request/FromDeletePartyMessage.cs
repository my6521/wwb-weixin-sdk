using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace WWB.Weixin.Work.ServerMessages.Request
{
    [XmlRoot("xml")]
    [Serializable]
    public class FromDeletePartyMessage : FromMessageBase
    {
        [XmlElement("ToUserName")]
        public string ToUserName { get; set; }

        [XmlElement("FromUserName")]
        public string FromUserName { get; set; }

        [XmlElement("Id")]
        public int Id { get; set; }
    }
}