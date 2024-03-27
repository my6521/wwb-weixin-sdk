using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WWB.Weixin.Work
{
    [Serializable]
    public class WxWorkException : Exception
    {
        public WxWorkException()
        {
        }

        public WxWorkException(string message) : base(message)
        {
        }

        public WxWorkException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected WxWorkException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}