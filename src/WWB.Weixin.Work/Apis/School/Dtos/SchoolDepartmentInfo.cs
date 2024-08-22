using System.Collections.Generic;

namespace WWB.Weixin.Work.Apis.School.Dtos
{
    public class SchoolDepartmentInfo
    {
        public string name { get; set; }
        public int parentid { get; set; }
        public int id { get; set; }
        public int type { get; set; }
        public int register_year { get; set; }

        public int standard_grade { get; set; }

        public long order { get; set; }

        public List<SchoolDepartmentAdminInfo> department_admins { get; set; }
    }

    public class SchoolDepartmentAdminInfo
    {
        public string userid { get; set; }
        public int type { get; set; }
    }
}