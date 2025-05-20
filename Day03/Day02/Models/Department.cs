using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day02.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manager { get; set; }

        public virtual List<Course> Courses { get; set; }
        public virtual List<Instructor> instructors { get; set; }
        public virtual List<Trainee> trainees { get; set; }
    }
}
