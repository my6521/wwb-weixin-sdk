using System.Collections.Generic;

namespace WWB.Weixin.Work.Models
{
    public class DepartmentInfo
    {
        public int id { get; set; }
        public string name { get; set; }
        public string name_en { get; set; }
        public List<string> department_leader { get; set; }
        public int parentid { get; set; }
        public long order { get; set; }
    }
}