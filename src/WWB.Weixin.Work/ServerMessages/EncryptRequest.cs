using System;
using System.Xml.Serialization;

namespace WWB.Weixin.Work.ServerMessages
{
    [XmlRoot("xml")]
    [Serializable]
    public class EncryptRequest
    {
        /// <summary>
        /// 企业微信的CorpID，当为第三方应用回调事件时，CorpID的内容为suiteid
        /// </summary>
        [XmlElement("ToUserName")]
        public string ToUserName { get; set; }

        /// <summary>
        /// 接收的应用id，可在应用的设置页面获取。仅应用相关的回调会带该字段
        /// </summary>
        [XmlElement("AgentID")]
        public string AgentID { get; set; }

        /// <summary>
        /// 消息结构体加密后的字符串
        /// </summary>
        [XmlElement("Encrypt")]
        public string Encrypt { get; set; }
    }
}