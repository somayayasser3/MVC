using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day02.Models
{
    public class CourseResult
    {
        [Key]
        public int Id { get; set; }
        public int Degree { get; set; }

        [ForeignKey("course")]
        public int Crs_Id { get; set; }
        public virtual Course course { get; set; }
        [ForeignKey("trainee")]
        public int Trainee_Id { get; set; }
        public virtual Trainee trainee { get; set; }
    }
}
