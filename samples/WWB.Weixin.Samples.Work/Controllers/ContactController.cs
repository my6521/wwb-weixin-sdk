using Microsoft.AspNetCore.Mvc;
using WWB.Weixin.Work;
using WWB.Weixin.Work.Apis.Contact;

namespace WWB.Weixin.Samples.Work.Controllers
{
    [ApiController]
    [Route("/[controller]/[action]")]
    public class ContactController : ControllerBase
    {
        private readonly ILogger<ContactController> _logger;
        private readonly IContactApi _contactApi;
        private readonly ITokenManager _tokenManager;

        public ContactController(ILogger<ContactController> logger, IContactApi contactApi, ITokenManager tokenManager)
        {
            _logger = logger;
            _contactApi = contactApi;
            _tokenManager = tokenManager;
        }

        [HttpGet]
        public async Task<IActionResult> DepartmentList(string corpId, string corpSecret)
        {
            var token = await _tokenManager.GetToken(corpId, corpSecret);
            var list = await _contactApi.GetDepartmentList(token);

            return new JsonResult(list);
        }
    }
}