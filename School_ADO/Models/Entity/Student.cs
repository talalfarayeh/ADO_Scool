using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School_ADO.Models.Entity
{
    public class Student
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Grade { get; set; }
    }
}