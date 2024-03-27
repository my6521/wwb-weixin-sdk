﻿using System;
using System.Runtime.Serialization;

namespace WWB.Weixin.SDK
{
    [Serializable]
    public class WxSdkException : Exception
    {
        public WxSdkException()
        {
        }

        public WxSdkException(string message) : base(message)
        {
        }

        public WxSdkException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected WxSdkException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}