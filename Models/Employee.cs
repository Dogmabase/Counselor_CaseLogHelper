using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaseLogger3.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        [Display(Name = "Employee ID")]
        public int EmployeeNum { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Password { get; set; }
        public virtual IList<Case> Case { get; set; }
    }
}