using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMVVM_11_.Model;

namespace WpfMVVM_11_.Context
{
    public class CoursesContext : DbContext
    {
        static CoursesContext()
        {
            //Database.SetInitializer<CoursesContext>(new CoursesContextInitializer());
        }
        public CoursesContext() : base("CoursesConnection")
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
    }
}
