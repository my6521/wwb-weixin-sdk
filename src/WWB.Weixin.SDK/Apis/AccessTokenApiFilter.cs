using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using WebApiClientCore;
using WebApiClientCore.Attributes;

namespace WWB.Weixin.SDK.Apis
{
    public class AccessTokenApiFilter : ApiFilterAttribute
    {
        public override async Task OnRequestAsync(ApiRequestContext context)
        {
            ITokenManager tokenManager = context.HttpContext.ServiceProvider.GetRequiredService<ITokenManager>();
            string accessToken = await tokenManager.GetAccessTokenAsync();
            context.HttpContext.RequestMessage.AddUrlQuery("access_token", accessToken);
        }

        public override Task OnResponseAsync(ApiResponseContext context)
        {
            return Task.CompletedTask;
        }
    }
}