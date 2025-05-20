namespace Day02.ViewModels
{
    public enum Status
    {
        Passed, Failed
    }
    public class Trainee_CourseViewModel
    {
        public int TID { get; set; }
        public int CID { get; set; }
        public string? Address { get; set; }
        public string TraineeName { get; set; }
        public string CourseName { get; set;}
        public string Imag { get; set; }
        public Status status { get; set; }
        public int Degree { get; set; }
        public int MinGrade { get; set; }
        public string Color { get; set; }
    }
}
