using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCSignalRDemo.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int RollNo { get; set; }
    }

    public class SchoolContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
    }
}