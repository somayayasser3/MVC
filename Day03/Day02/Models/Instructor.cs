using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day02.Models
{
    public class Instructor
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Imag { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Salary { get; set; }
        public string? Address { get; set; }

        [ForeignKey("department")]
        public int Dept_id { get; set; }
        public virtual Department department { get; set; }
        [ForeignKey("course")]
        public int Crs_Id { get;  set; }
        public virtual Course course { get; set; }

    }
}
