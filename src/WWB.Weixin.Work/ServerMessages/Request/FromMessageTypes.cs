using System;
using System.Collections.Generic;
using System.Text;

namespace WWB.Weixin.Work.ServerMessages.Request
{
    public class FromMessageTypes
    {
        public const string suite_ticket = "suite_ticket";
        public const string create_auth = "create_auth";
        public const string change_auth = "change_auth";
        public const string cancel_auth = "cancel_auth";
        public const string reset_permanent_code = "reset_permanent_code";
    }
}