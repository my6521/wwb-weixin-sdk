using System;
using System.Collections.Generic;
using System.Text;

namespace WWB.Weixin.Work.Apis.Message.Dtos
{
    public class SendImageMessage : SendMessageBase
    {
        public SendImageMessage() : base(MessageTypes.image)
        {
        }
    }
}