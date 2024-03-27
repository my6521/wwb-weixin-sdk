using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiClientCore.Attributes;
using WWB.Weixin.Work.Apis.Message.Dtos;
using WWB.Weixin.Work.Apis.Token.Dtos;

namespace WWB.Weixin.Work.Apis.Message
{
    public interface IMessageApi : IBaseHttpApi
    {
        [HttpPost("/cgi-bin/message/send")]
        Task<SendMessageResponse> Send([PathQuery] string access_token, [JsonNetContent] SendMessageRequest request);

        [HttpPost("/cgi-bin/message/recall")]
        Task<BaseResponse> Recall([PathQuery] string access_token, [JsonNetContent] RecallMessageRequest request);
    }
}