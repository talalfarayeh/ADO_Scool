using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School_ADO.Models.Entity
{
    public class Class
    {
        public int ClassID { get; set; }
        public string ClassName { get; set; }
        public int TeacherID { get; set; }
        public int StudentID { get; set; }

        public string TeacherName { get; set; }  
        public string StudentName { get; set; }  
    }
}