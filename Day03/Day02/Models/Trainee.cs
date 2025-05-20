using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day02.Models
{
    public class Trainee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Imag { get; set; }
        public string? Address { get; set; }
        public int Grade { get; set; }

        [ForeignKey("department")]
        public int Dept_Id { get; set; }
        public virtual Department department { get; set; }
        public virtual List<CourseResult> courseResults { get; set; }

    }
}
