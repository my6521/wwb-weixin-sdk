﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;
using WWB.Weixin.SDK.ServerMessages;

namespace WWB.Weixin.SDK.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("/WxSdk")]
    public class WxController : ControllerBase
    {
        private readonly ServerMessageHandler serverMessageHandler;
        private readonly ILogger<WxController> logger;

        public WxController(ServerMessageHandler serverMessageHandler, ILogger<WxController> logger)
        {
            this.serverMessageHandler = serverMessageHandler;
            this.logger = logger;
        }

        /// <summary>
        /// 检查签名
        /// </summary>
        /// <param name="signature">The signature<see cref="string"/></param>
        /// <param name="timestamp">The timestamp<see cref="string"/></param>
        /// <param name="nonce">The nonce<see cref="string"/></param>
        /// <param name="echostr">The echostr<see cref="string"/></param>
        /// <returns>The <see cref="ActionResult"/></returns>
        [HttpGet("")]
        public ActionResult CheckSignature(string signature, string timestamp, string nonce,
            string echostr)
        {
            return Content(serverMessageHandler.CheckSignature(signature, timestamp, nonce) ? echostr : "验证签名出错！");
        }

        /// <summary>
        /// 处理服务器事件消息
        /// </summary>
        /// <param name="signature"></param>
        /// <param name="timestamp"></param>
        /// <param name="nonce"></param>
        /// <param name="echostr"></param>
        /// <returns></returns>
        [HttpPost("")]
        public async Task<ActionResult> HandleMessage(string signature, string timestamp, string nonce,
            string echostr)
        {
            logger.LogDebug("正在处理微信服务器消息...");

            using var reader = new StreamReader(Request.Body);
            var xmlStr = await reader.ReadToEndAsync();
            //检查签名
            if (!serverMessageHandler.CheckSignature(signature, timestamp, nonce))
            {
                logger.LogWarning($"签名验证出错:\n signature:{signature}\t timestamp:{timestamp}\t nonce:{nonce}\t echostr:{echostr}");
                return BadRequest("签名验证出错!");
            }
            logger.LogDebug("签名校验完成...");
            //处理事件消息
            var result = await serverMessageHandler.HandleMessage(xmlStr);
            if (result == null)
                return Ok();
            var toXml = result.ToXml();
            logger.LogDebug($"微信服务器事件处理成功，返回格式为:{Environment.NewLine}{toXml}");
            return Content(toXml);
        }
    }
}