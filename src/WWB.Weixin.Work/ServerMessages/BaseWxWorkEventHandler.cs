using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WWB.Weixin.Work.Apis.Service;
using WWB.Weixin.Work.Apis.Service.Dtos;
using WWB.Weixin.Work.ServerMessages.Request;
using WWB.Weixin.Work.ServerMessages.Response;

namespace WWB.Weixin.Work.ServerMessages
{
    public abstract class BaseWxWorkEventHandler : IWxWorkEventHandler
    {
        public virtual Task OnCancelAuthRequest(FromCancelAuthMessage request, WxWorkOptions options)
        {
            return Task.CompletedTask;
        }

        public virtual Task OnChangeAuthRequest(FromChangeAuthMessage request, WxWorkOptions options)
        {
            return Task.CompletedTask;
        }

        public virtual Task OnCreateAuthRequest(FromCreateAuthMessage request, WxWorkOptions options)
        {
            return Task.CompletedTask;
        }

        public virtual Task OnResetPermanentCodeRequest(FromResetPermanentCodeMessage request, WxWorkOptions options)
        {
            return Task.CompletedTask;
        }

        public virtual Task OnSuiteTicketRequest(FromSuiteTicketMessage request, WxWorkOptions options)
        {
            return Task.CompletedTask;
        }

        public virtual Task OnCreateUserRequest(FromCreateUserMessage request, WxWorkOptions options)
        {
            return Task.CompletedTask;
        }

        public virtual Task OnUpdateUserRequest(FromUpdateUserMessage request, WxWorkOptions options)
        {
            return Task.CompletedTask;
        }

        public virtual Task OnDeleteUserRequest(FromDeleteUserMessage request, WxWorkOptions options)
        {
            return Task.CompletedTask;
        }

        public virtual Task OnCreatePartyRequest(FromCreatePartyMessage request, WxWorkOptions options)
        {
            return Task.CompletedTask;
        }

        public virtual Task OnUpdatePartyRequest(FromUpdatePartyMessage request, WxWorkOptions options)
        {
            return Task.CompletedTask;
        }

        public virtual Task OnDeletePartyRequest(FromDeletePartyMessage request, WxWorkOptions options)
        {
            return Task.CompletedTask;
        }

        public virtual Task OnUpdateTagRequest(FromUpdateTagMessage request, WxWorkOptions options)
        {
            return Task.CompletedTask;
        }
    }
}