using System.Threading.Tasks;
using WWB.Weixin.SDK.ServerMessages.Request;
using WWB.Weixin.SDK.ServerMessages.Response;

namespace WWB.Weixin.SDK.ServerMessages
{
    /// <summary>
    /// 微信服务消息、事件处理器
    /// </summary>
    public interface IWxSdkEventsHandler
    {
        /// <summary>
        /// 处理服务器消息事件
        /// </summary>
        /// <param name="fromMessage"></param>
        /// <returns></returns>
        Task<ToMessageBase> Execute(IFromMessage fromMessage);
    }
}