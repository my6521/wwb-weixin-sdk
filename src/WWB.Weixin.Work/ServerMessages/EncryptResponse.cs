using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using WWB.Weixin.Utility;

namespace WWB.Weixin.Work.ServerMessages
{
    [XmlRoot("xml")]
    [Serializable]
    public class EncryptResponse
    {
        [XmlElement("MsgSignature")]
        public string MsgSignature { get; set; }

        [XmlElement("TimeStamp")]
        public string TimeStamp { get; set; }

        [XmlElement("Nonce")]
        public string Nonce { get; set; }

        [XmlElement("Encrypt")]
        public string Encrypt { get; set; }
    }

    public static class EncryptResponseExtensions
    {
        public static string ToXml(this EncryptResponse msg)
        {
            return msg == null ? null : XmlUtility.SerializeObjectWithoutNamespace(msg);
        }
    }
}