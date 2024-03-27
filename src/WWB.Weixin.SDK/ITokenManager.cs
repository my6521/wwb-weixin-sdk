using System.Threading.Tasks;

namespace WWB.Weixin.SDK
{
    public interface ITokenManager
    {
        Task<string> GetAccessTokenAsync();
    }
}