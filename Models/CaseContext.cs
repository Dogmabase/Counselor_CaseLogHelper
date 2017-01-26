using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CaseLogger3.Models
{
    public class CaseContext : DbContext
    {
        public CaseContext() : base("CaseContext") { }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<Case> cases { get; set; }
    }
}