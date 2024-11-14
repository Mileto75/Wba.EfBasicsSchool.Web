using Microsoft.EntityFrameworkCore;
using Wba.EfBasics.Core.Entities;

namespace Wba.EfBasics.Web.Data.Seeding
{
    public static class Seeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            //seed the data
            //build the arrays
            //Addresses
            var addresses = new Address[]
            {
                new Address{Id = 1,FullAdress = "Langestraat 67, 8370 Blankenberge", Created = DateTime.Now},
                new Address{Id = 2,FullAdress = "Molenstraat 78, 8000 Brugge", Created = DateTime.Now},
            };
            //teachers
            var teachers = new Teacher[]
            {
                new Teacher { Id = 1,Firstname = "Bart",Lastname = "Soete",AddressId = 2,Created = DateTime.Now},
                new Teacher { Id = 2,Firstname = "Mileto",Lastname = "Di Marco",AddressId = 1,Created = DateTime.Now},
            };
            var students = new Student[]
            {
                new Student { Id = 1,Firstname = "Mark",Lastname = "Knopfler",Created = DateTime.Now},
                new Student { Id = 2,Firstname = "Jimi",Lastname = "Hendrix",Created = DateTime.Now},
                new Student { Id = 3,Firstname = "Rory",Lastname = "Gallagher",Created = DateTime.Now},
                new Student { Id = 4,Firstname = "Tim",Lastname = "Henson",Created = DateTime.Now},
            };
            //courses
            var courses = new Course[]
            {
                new Course { Id = 1, Name = "Web Backend",TeacherId = 2,Created = DateTime.Now},
                new Course { Id = 2, Name = "Web Frontend Advanced",TeacherId = 1,Created = DateTime.Now},
            };
            //CoursesStudent
            var coursesStudents = new[]
            {
                new {CoursesId = 1, StudentsId = 1 },
                new {CoursesId = 1, StudentsId = 2 },
                new {CoursesId = 1, StudentsId = 3 },
                new {CoursesId = 1, StudentsId = 4 },
                new {CoursesId = 2, StudentsId = 1 },
                new {CoursesId = 2, StudentsId = 2 },
                new {CoursesId = 2, StudentsId = 3 },
                new {CoursesId = 2, StudentsId = 4 },
            };

            //call the hasdata methods
            //address
            modelBuilder.Entity<Address>().HasData(addresses);
            //teachers
            modelBuilder.Entity<Teacher>().HasData(teachers);
            //students
            modelBuilder.Entity<Student>().HasData(students);
            //courses
            modelBuilder.Entity<Course>().HasData(courses);
            //CourseStudents
            modelBuilder.Entity($"{nameof(Course)}{nameof(Student)}")
                .HasData(coursesStudents);
        }
    }
}
