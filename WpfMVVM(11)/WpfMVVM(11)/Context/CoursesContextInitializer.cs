using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMVVM_11_.Model;

namespace WpfMVVM_11_.Context
{
    class CoursesContextInitializer : DropCreateDatabaseAlways<CoursesContext>
    {
        protected override void Seed(CoursesContext db)
        {
            List<Student> students = new List<Student>
            {
                new Student{Name= "Пыркин Станислав"},
                new Student{Name= "Жукова Александра"},
                new Student{Name= "Совельев Павел"}
            };
            List<Subject> subjects = new List<Subject>
            {
                new Subject{Name = "ООП", LectorName = "Иванов Иван", NumberOfHours = 157},
                new Subject{Name = "БД", LectorName = "Золотопуп Григорий", NumberOfHours = 207},
                new Subject{Name = "Кгиг", LectorName = "Михасева Зинаида", NumberOfHours = 182}
            };
            db.Students.AddRange(students);
            db.Subjects.AddRange(subjects);
            db.SaveChanges();
        }
    }
}

