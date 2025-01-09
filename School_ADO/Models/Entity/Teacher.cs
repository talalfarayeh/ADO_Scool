using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School_ADO.Models.Entity
{
    public class Teacher
    {
        public int TeacherID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Subject { get; set; }
    }
}