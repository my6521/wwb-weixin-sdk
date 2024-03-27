using System.Threading.Tasks;
using WWB.Weixin.Work.ServerMessages.Request;

namespace WWB.Weixin.Work.ServerMessages
{
    public interface IWxWorkEventHandler
    {
        Task OnCancelAuthRequest(FromCancelAuthMessage request, WxWorkOptions options);

        Task OnChangeAuthRequest(FromChangeAuthMessage request, WxWorkOptions options);

        Task OnCreateAuthRequest(FromCreateAuthMessage request, WxWorkOptions options);

        Task OnResetPermanentCodeRequest(FromResetPermanentCodeMessage request, WxWorkOptions options);

        Task OnSuiteTicketRequest(FromSuiteTicketMessage request, WxWorkOptions options);
    }
}