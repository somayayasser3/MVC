using System.ComponentModel.DataAnnotations;

namespace Day02.ViewModels
{
    public class CourseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Degree { get; set; }
        public int MinDegree { get; set; }
        public int Hours { get; set; }
    
    }
}
