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

        public const string change_contact = "change_contact";
        public const string create_user = "create_user";
        public const string update_user = "update_user";
        public const string delete_user = "delete_user";
        public const string create_party = "create_party";
        public const string update_party = "update_party";
        public const string delete_party = "delete_party";
        public const string update_tag = "update_tag";
    }
}