using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using WWB.Weixin.Utility;
using WWB.Weixin.Work.ServerMessages;

namespace WWB.Weixin.Work.Controllers
{
    /// <summary>
    ///
    /// </summary>
    [ApiController]
    [AllowAnonymous]
    [Route("/WxWork")]
    public class WxWorkController : ControllerBase
    {
        private readonly ILogger<WxWorkController> _logger;
        private readonly ServerMessageHandler _serverMessageHandler;

        /// <summary>
        ///
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="serverMessageHandler"></param>
        public WxWorkController(ILogger<WxWorkController> logger, ServerMessageHandler serverMessageHandler)
        {
            _logger = logger;
            _serverMessageHandler = serverMessageHandler;
        }

        /// <summary>
        /// 验证签名
        /// </summary>
        /// <param name="timestamp"></param>
        /// <param name="nonce"></param>
        /// <param name="echostr"></param>
        /// <param name="msg_signature"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get([Required] string timestamp, [Required] string nonce, [Required] string echostr, [Required] string msg_signature)
        {
            if (!_serverMessageHandler.VerifyUrl(timestamp, nonce, echostr, msg_signature, out string reply))
            {
                _logger.LogError("签名验证出错!");
                return Content("fail");
            }

            _logger.LogDebug("验证URL完成...");
            return Content(reply);
        }

        /// <summary>
        /// 消息回调
        /// </summary>
        /// <param name="timestamp"></param>
        /// <param name="nonce"></param>
        /// <param name="msg_signature"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([Required] string timestamp, [Required] string nonce, [Required] string msg_signature)
        {
            _logger.LogDebug("正在处理微信服务器消息...");

            using var reader = new StreamReader(Request.Body, Encoding.UTF8);
            string postData = await reader.ReadToEndAsync();
            var encryptRequest = XmlUtility.DeserializeObject<EncryptRequest>(postData);

            if (!_serverMessageHandler.CheckSignature(timestamp, nonce, encryptRequest.Encrypt, msg_signature))
            {
                _logger.LogWarning($"签名验证出错:\n signature:{msg_signature}\t timestamp:{timestamp}\t nonce:{nonce}\t echostr:{encryptRequest.Encrypt}");
                return BadRequest("签名验证出错!");
            }

            _logger.LogDebug("签名校验完成...");

            var result = await _serverMessageHandler.HandleMessage(encryptRequest);
            if (result == null)
                return Content("success");

            var toXml = result.ToXml();
            _logger.LogDebug($"微信服务器事件处理成功，返回格式为:{Environment.NewLine}{toXml}");

            return Content(toXml);
        }
    }
}