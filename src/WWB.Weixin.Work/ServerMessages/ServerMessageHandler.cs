using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WWB.Weixin.Utility;
using WWB.Weixin.Work.ServerMessages.Request;
using WWB.Weixin.Work.ServerMessages.Response;

namespace WWB.Weixin.Work.ServerMessages
{
    public class ServerMessageHandler
    {
        private readonly ILogger<ServerMessageHandler> _logger;
        private readonly IServiceProvider _serviceProvider;
        private readonly WxWorkOptions _options;

        public ServerMessageHandler(ILogger<ServerMessageHandler> logger, IServiceProvider serviceProvider, WxWorkFuncs weixinWorkFuncs)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
            _options = weixinWorkFuncs.GetWxWorkOptions();
        }

        public bool VerifyUrl(string timestamp, string nonce, string echostr, string signature, out string replyEchoStr)
        {
            replyEchoStr = string.Empty;
            if (CheckSignature(timestamp, nonce, echostr, signature))
            {
                replyEchoStr = AESUtility.AESDecrypt(echostr, _options.PushEncodingAESKey, out string cpid);
                return true;
            }

            return false;
        }

        public bool CheckSignature(string timestamp, string nonce, string echostr, string signature)
        {
            return GenerateSignature(timestamp, nonce, echostr) == signature;
        }

        public async Task<EncryptResponse> HandleMessage(EncryptRequest encryptRequest)
        {
            var decryptMsg = AESUtility.AESDecrypt(encryptRequest.Encrypt, _options.PushEncodingAESKey, out string cpid);
            var xmlElement = XElement.Parse(decryptMsg);
            var infoTypeElement = xmlElement.Element("InfoType");
            var msgTypeElement = xmlElement.Element("MsgType");

            var handler = _serviceProvider.GetService<IWxWorkEventHandler>();
            if (handler == null)
            {
                throw new WxWorkException($"接收公众号服务端事件消息需要先注册 {nameof(IWxWorkEventHandler)} ！");
            }

            if (infoTypeElement != null)
            {
                var infoType = infoTypeElement.Value.Trim().ToLower();
                switch (infoType)
                {
                    case FromMessageTypes.suite_ticket:
                        await ExecuteHandler<FromSuiteTicketMessage>(decryptMsg, (request, options) => handler.OnSuiteTicketRequest(request, options));
                        break;

                    case FromMessageTypes.create_auth:
                        await ExecuteHandler<FromCreateAuthMessage>(decryptMsg, (request, options) => handler.OnCreateAuthRequest(request, options));
                        break;

                    case FromMessageTypes.change_auth:
                        await ExecuteHandler<FromChangeAuthMessage>(decryptMsg, (request, options) => handler.OnChangeAuthRequest(request, options));
                        break;

                    case FromMessageTypes.cancel_auth:
                        await ExecuteHandler<FromCancelAuthMessage>(decryptMsg, (request, options) => handler.OnCancelAuthRequest(request, options));
                        break;

                    case FromMessageTypes.reset_permanent_code:
                        await ExecuteHandler<FromResetPermanentCodeMessage>(decryptMsg, (request, options) => handler.OnResetPermanentCodeRequest(request, options));
                        break;

                    default:
                        break;
                }
            }
            else if (msgTypeElement != null)
            {
                var msgType = msgTypeElement.Value.Trim().ToLower();
                if (msgType == "event")
                {
                    var evt = xmlElement.Element("Event").Value.Trim().ToLower();
                    switch (evt)
                    {
                        case FromMessageTypes.change_contact:
                            {
                                var changeType = xmlElement.Element("ChangeType").Value.Trim().ToLower();
                                switch (changeType)
                                {
                                    case FromMessageTypes.create_user:
                                        await ExecuteHandler<FromCreateUserMessage>(decryptMsg, (request, options) => handler.OnCreateUserRequest(request, options));
                                        break;

                                    case FromMessageTypes.update_user:
                                        await ExecuteHandler<FromUpdateUserMessage>(decryptMsg, (request, options) => handler.OnUpdateUserRequest(request, options));
                                        break;

                                    case FromMessageTypes.delete_user:
                                        await ExecuteHandler<FromDeleteUserMessage>(decryptMsg, (request, options) => handler.OnDeleteUserRequest(request, options));
                                        break;

                                    case FromMessageTypes.create_party:
                                        await ExecuteHandler<FromCreatePartyMessage>(decryptMsg, (request, options) => handler.OnCreatePartyRequest(request, options));
                                        break;

                                    case FromMessageTypes.update_party:
                                        await ExecuteHandler<FromUpdatePartyMessage>(decryptMsg, (request, options) => handler.OnUpdatePartyRequest(request, options));
                                        break;

                                    case FromMessageTypes.delete_party:
                                        await ExecuteHandler<FromDeletePartyMessage>(decryptMsg, (request, options) => handler.OnDeletePartyRequest(request, options));
                                        break;

                                    case FromMessageTypes.update_tag:
                                        await ExecuteHandler<FromUpdateTagMessage>(decryptMsg, (request, options) => handler.OnUpdateTagRequest(request, options));
                                        break;

                                    default:
                                        break;
                                }
                            }
                            break;

                        default:
                            break;
                    }
                }
                else
                {
                }
            }
            else
            {
                throw new WxWorkException("消息类型不能为空");
            }

            return null;
        }

        private async Task ExecuteHandler<T>(string xmlStr, Func<T, WxWorkOptions, Task> messageHandler) where T : class, IFromMessage
        {
            var type = typeof(T);

            var request = XmlUtility.DeserializeObject<T>(xmlStr);
            if (request != null)
                await messageHandler(request, _options);
            else
                _logger.LogWarning($"序列化类型【{type.FullName}】失败");
        }

        private string GenerateSignature(string timestamp, string nonce, string echostr)
        {
            var arr = new List<string> { _options.PushToken, timestamp, nonce, echostr };
            arr.Sort(StringComparer.Ordinal);
            var arrString = string.Join("", arr);

            using (var sha = SHA1.Create())
            {
                var enc = new ASCIIEncoding();
                byte[] dataToHash = enc.GetBytes(arrString);
                byte[] dataHashed = sha.ComputeHash(dataToHash);
                var hash = BitConverter.ToString(dataHashed).Replace("-", "");

                return hash.ToLower();
            }
        }

        //private EncryptResponse BuildResponse(string receiveid, BaseResponse toMessage)
        //{
        //    var replyMsg = XmlUtility.SerializeObjectWithoutNamespace(toMessage);
        //    var encryptMsg = AESUtility.AESEncrypt(replyMsg, _options.PushEncodingAESKey, receiveid);

        //    var timestamp = DateTime.Now.ConvertToTimeStamp().ToString();
        //    var nonce = Guid.NewGuid().ToString("N");
        //    var sign = GenerateSignature(timestamp, nonce, encryptMsg);

        //    return new EncryptResponse()
        //    {
        //        Encrypt = encryptMsg,
        //        MsgSignature = sign,
        //        TimeStamp = timestamp,
        //        Nonce = nonce,
        //    };
        //}
    }
}