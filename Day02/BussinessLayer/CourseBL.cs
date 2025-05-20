using Day02.Models;
using Day02.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Day02.BussinessLayer
{
    public class CourseBL
    {
        public UniversityContext universityCont;
        public CourseBL(UniversityContext universityContext)
        {
            universityCont = universityContext;
        }

        public List<CourseViewModel> AllCouses()
        {
            return universityCont.Courses.Select(c => new CourseViewModel
            {
                Id = c.Id,
                Name = c.Name,
                Degree = c.Degree,
                MinDegree = c.MinDegree,
                Hours = c.Hours,
            }).ToList();
        }

        public List<Trainee_CourseViewModel> AllTraineeswithCourses()
        {
            return universityCont.CourseResults.Select(t =>
                new Trainee_CourseViewModel
                {
                    TID = t.Trainee_Id,
                    CID = t.Crs_Id,
                    TraineeName = t.trainee.Name,
                    CourseName = t.course.Name,
                    Address = t.trainee.Address,
                    Degree = t.Degree,
                    MinGrade = t.course.MinDegree,
                    Imag = t.trainee.Imag,
                    Color = t.Degree >= t.course.MinDegree ? "green" : "red",
                    status = t.Degree >= t.course.MinDegree ? Status.Passed : Status.Failed
                }).ToList();
        }
        public List<Trainee_CourseViewModel> CourseAllTrainees(int Cid)
        {
            return AllTraineeswithCourses().Where(c => c.CID == Cid).ToList();
        }

        public Trainee_CourseViewModel SpecificTraineeGradePerCourse(int Cid, int Tid)
        {
            return AllTraineeswithCourses().Where(c => (c.CID == Cid && c.TID == Tid)).SingleOrDefault() ?? new Trainee_CourseViewModel();
        }
    }
    
}
