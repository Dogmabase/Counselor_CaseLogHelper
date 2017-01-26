using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaseLogger3.Models
{
    public class Case
    {
        public int CaseID { get; set; }         //autoset
        public int EmpID { get; set; }          //autofill
        public int StudID { get; set; }         //otional autofill?
        public string Date { get; set; }        //autofill

        [Required]
        public string CaseType { get; set; }

        [Required]
        public string Outcome { get; set; }

        public Employee Employee { get; set; }

    }
}