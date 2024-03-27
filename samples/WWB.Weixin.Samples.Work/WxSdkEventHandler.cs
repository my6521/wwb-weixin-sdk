using WWB.Weixin.SDK.ServerMessages;
using WWB.Weixin.SDK.ServerMessages.Request;
using WWB.Weixin.SDK.ServerMessages.Response;

namespace WWB.Weixin.Samples.Work
{
    public class WxSdkEventHandler : IWxSdkEventsHandler
    {
        public Task<ToMessageBase> Execute(IFromMessage fromMessage)
        {
            throw new NotImplementedException();
        }
    }
}