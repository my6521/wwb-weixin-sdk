using WWB.Weixin.Work;
using WWB.Weixin.Work.Apis.Contact;
using WWB.Weixin.Work.Apis.Service;
using WWB.Weixin.Work.ServerMessages;
using WWB.Weixin.Work.ServerMessages.Request;

namespace WWB.Weixin.Samples.Work
{
    public class WxWorkEventHandler : BaseWxWorkEventHandler
    {
        private readonly ITokenManager _tokenManager;
        private readonly IServiceApi _serviceApi;
        private readonly ILogger<WxWorkEventHandler> _logger;
        private readonly IContactApi _contactApi;

        public WxWorkEventHandler(ITokenManager tokenManager, IServiceApi serviceApi, ILogger<WxWorkEventHandler> logger, IContactApi contactApi)
        {
            _tokenManager = tokenManager;
            _serviceApi = serviceApi;
            _logger = logger;
            _contactApi = contactApi;
        }

        public override Task OnCreateAuthRequest(FromCreateAuthMessage request, WxWorkOptions options)
        {
            return Task.CompletedTask;
        }

        public override Task OnResetPermanentCodeRequest(FromResetPermanentCodeMessage request, WxWorkOptions options)
        {
            return Task.CompletedTask;
        }

        public override Task OnSuiteTicketRequest(FromSuiteTicketMessage request, WxWorkOptions options)
        {
            return Task.CompletedTask;
        }
    }
}