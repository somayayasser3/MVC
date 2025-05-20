using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Day02.Models
{
    public class UniversityContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<CourseResult> CourseResults { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-FPIMC2H\\SQLEXPRESS;Initial Catalog=DBUniversity;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(
               new Department { Id = 1, Name = "CS", Manager = "Ahmed" },
               new Department { Id = 2, Name = "Math", Manager = "Ali" },
               new Department { Id = 3, Name = "OS", Manager = "Omar" },
               new Department { Id = 4, Name = "Dotnet", Manager = "Osama" }
           );

            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, Name = "Introduction to Programming", Degree = "Bachelor", MinDegree = 50, Dept_id = 1 },
                new Course { Id = 2, Name = "Data Structures and Algorithms", Degree = "Bachelor", MinDegree = 60, Dept_id = 1 },
                new Course { Id = 3, Name = "Database Systems", Degree = "Bachelor", MinDegree = 55, Dept_id = 1 },
                new Course { Id = 4, Name = "Calculus I", Degree = "Bachelor", MinDegree = 50, Dept_id = 2 },
                new Course { Id = 5, Name = "Linear Algebra", Degree = "Bachelor", MinDegree = 55, Dept_id = 2 },
                new Course { Id = 6, Name = "Arch", Degree = "Bachelor", MinDegree = 60, Dept_id = 3 },
                new Course { Id = 7, Name = "ML", Degree = "Master", MinDegree = 65, Dept_id = 3 },
                new Course { Id = 8, Name = "Genetic Algorithms", Degree = "Bachelor", MinDegree = 55, Dept_id = 4 }
            );

            modelBuilder.Entity<Instructor>().HasData(
                new Instructor { Id = 1, Name = "Ahmed", Imag = "m.png", Salary = 65000M, Address = "Giza", Dept_id = 1, Crs_Id = 1 },
                new Instructor { Id = 2, Name = "Sarah", Imag = "f.jpg", Salary = 72000M, Address = "Giza", Dept_id = 1, Crs_Id = 2 },
                new Instructor { Id = 3, Name = "Alaa", Imag = "f.jpg", Salary = 68000M, Address = "Cairo", Dept_id = 1, Crs_Id = 3 },
                new Instructor { Id = 4, Name = "Nour", Imag = "f.jpg", Salary = 70000M, Address = "Alex", Dept_id = 2, Crs_Id = 4 },
                new Instructor { Id = 5, Name = "Mustafa", Imag = "m.png", Salary = 75000M, Address = "Monoufia", Dept_id = 2, Crs_Id = 5 },
                new Instructor { Id = 6, Name = "Mohamed", Imag = "m.png", Salary = 80000M, Address = "Aswan", Dept_id = 3, Crs_Id = 6 },
                new Instructor { Id = 7, Name = "Yousef", Imag = "m.png", Salary = 85000M, Address = "Luxur", Dept_id = 3, Crs_Id = 7 },
                new Instructor { Id = 8, Name = "Yassin", Imag = "m.png", Salary = 67000M, Address = "Cairo", Dept_id = 4, Crs_Id = 8 }
            );

            modelBuilder.Entity<Trainee>().HasData(
                new Trainee { Id = 1, Name = "Omar", Imag = "m.png", Address = "Giza", Grade = 70, Dept_Id = 1 },
                new Trainee { Id = 2, Name = "Ahmed", Imag = "m.png", Address = "Giza", Grade = 55, Dept_Id = 1 },
                new Trainee { Id = 3, Name = "Mahmoud", Imag = "m.png", Address = "Cairo", Grade = 80, Dept_Id = 1 },
                new Trainee { Id = 4, Name = "Fatma", Imag = "f.jpg", Address = "Monoufia", Grade = 75, Dept_Id = 2 },
                new Trainee { Id = 5, Name = "Omnia", Imag = "f.jpg", Address = "Alex", Grade =90, Dept_Id = 2 },
                new Trainee { Id = 6, Name = "Soha", Imag = "f.jpg", Address = "Alex", Grade = 66, Dept_Id = 3 },
                new Trainee { Id = 7, Name = "Amr", Imag = "m.png", Address = "Cairo", Grade = 95, Dept_Id = 3 },
                new Trainee { Id = 8, Name = "Eman", Imag = "m.png", Address = "Tanta", Grade = 77, Dept_Id = 4 },
                new Trainee { Id = 9, Name = "Mohamed", Imag = "m.png", Address = "Luxur", Grade = 100, Dept_Id = 4 }
            );

            modelBuilder.Entity<CourseResult>().HasData(
                new CourseResult { Id = 1, Degree = 85, Crs_Id = 1, Trainee_Id = 1 },
                new CourseResult { Id = 2, Degree = 92, Crs_Id = 2, Trainee_Id = 1 },
                new CourseResult { Id = 3, Degree = 78, Crs_Id = 3, Trainee_Id = 1 },
                new CourseResult { Id = 4, Degree = 88, Crs_Id = 1, Trainee_Id = 2 },
                new CourseResult { Id = 5, Degree = 76, Crs_Id = 2, Trainee_Id = 2 },
                new CourseResult { Id = 6, Degree = 90, Crs_Id = 1, Trainee_Id = 3 },
                new CourseResult { Id = 7, Degree = 95, Crs_Id = 4, Trainee_Id = 4 },
                new CourseResult { Id = 8, Degree = 82, Crs_Id = 5, Trainee_Id = 4 },
                new CourseResult { Id = 9, Degree = 87, Crs_Id = 4, Trainee_Id = 5 },
                new CourseResult { Id = 10, Degree = 91, Crs_Id = 6, Trainee_Id = 6 },
                new CourseResult { Id = 11, Degree = 84, Crs_Id = 7, Trainee_Id = 6 },
                new CourseResult { Id = 12, Degree = 79, Crs_Id = 6, Trainee_Id = 7 },
                new CourseResult { Id = 13, Degree = 93, Crs_Id = 8, Trainee_Id = 8 },
                new CourseResult { Id = 14, Degree = 86, Crs_Id = 8, Trainee_Id = 9 }
            );
        }
    }
}
