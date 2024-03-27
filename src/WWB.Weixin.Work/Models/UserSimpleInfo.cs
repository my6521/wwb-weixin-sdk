using System;
using System.Collections.Generic;
using System.Text;

namespace WWB.Weixin.Work.Models
{
    public class UserSimpleInfo
    {
        public string userid { get; set; }
        public string name { get; set; }
        public List<int> department { get; set; }
        public string open_userid { get; set; }
    }
}