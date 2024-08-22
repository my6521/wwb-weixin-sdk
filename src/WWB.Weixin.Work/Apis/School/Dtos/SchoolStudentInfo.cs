using System.Collections.Generic;

namespace WWB.Weixin.Work.Apis.School.Dtos
{
    public class SchoolStudentInfo
    {
        public string student_userid { get; set; }
        public string name { get; set; }
        public List<int> department { get; set; }

        public List<Parent> parents { get; set; }

        public class Parent
        {
            public string parent_userid { get; set; }
            public string relation { get; set; }
            public string mobile { get; set; }
            public int is_subscribe { get; set; }
            public string external_userid { get; set; }
        }
    }
}