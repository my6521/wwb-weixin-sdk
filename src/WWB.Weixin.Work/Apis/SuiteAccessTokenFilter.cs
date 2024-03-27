using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiClientCore;
using WebApiClientCore.Attributes;

namespace WWB.Weixin.Work.Apis
{
    public class SuiteAccessTokenFilter : ApiFilterAttribute
    {
        public override async Task OnRequestAsync(ApiRequestContext context)
        {
            ITokenManager tokenManager = context.HttpContext.ServiceProvider.GetRequiredService<ITokenManager>();
            string accessToken = await tokenManager.GetSuiteToken();
            context.HttpContext.RequestMessage.AddUrlQuery("suite_access_token", accessToken);
        }

        public override Task OnResponseAsync(ApiResponseContext context)
        {
            return Task.CompletedTask;
        }
    }
}