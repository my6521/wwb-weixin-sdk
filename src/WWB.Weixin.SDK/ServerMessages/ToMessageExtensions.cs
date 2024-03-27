using WWB.Weixin.SDK.ServerMessages.Response;
using WWB.Weixin.Utility;

namespace WWB.Weixin.SDK.ServerMessages
{
    /// <summary>
    /// 发送消息扩展
    /// </summary>
    public static class ToMessageExtensions
    {
        /// <summary>
        /// 序列化XML
        /// </summary>
        /// <param name="msg">发送消息</param>
        /// <returns></returns>
        public static string ToXml(this ToMessageBase msg)
        {
            //移除定义和命名空间
            return msg == null ? null : XmlUtility.SerializeObjectWithoutNamespace(msg);
        }
    }
}