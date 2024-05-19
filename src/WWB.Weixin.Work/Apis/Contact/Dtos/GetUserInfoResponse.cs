using System.Collections.Generic;

namespace WWB.Weixin.Work.Apis.Contact.Dtos
{
    public class GetUserInfoResponse : ApiResultBase
    {
        public string userid { get; set; }
        public string name { get; set; }
        public List<int> department { get; set; }
        public string open_userid { get; set; }
        public string position { get; set; }
    }
}