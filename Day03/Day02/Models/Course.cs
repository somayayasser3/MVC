using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day02.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Degree { get; set; }
        public int MinDegree { get; set; }
        public int Hours { get; set; }

        [ForeignKey("department")]
        public int Dept_id { get; set; }
        public virtual Department department { get; set; }
        public virtual List<Instructor> instructors { get; set; }
        public virtual List<CourseResult> courseResults { get; set; }
    }
}
