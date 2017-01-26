using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaseLogger3.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        [Display(Name="Student ID")]
        public int StudentNum { get; set; }
        [Display(Name="First Name")]
        public string Fname { get; set; }
        [Display(Name = "Last Name")]
        public string Lname { get; set; }
    }
}