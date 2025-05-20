using Day02.Models;
using Day02.ViewModels;
using System.Security.Cryptography;

namespace Day02.BussinessLayer
{
    public class TraineeBL
    {
        public UniversityContext universityCont;
        public TraineeBL(UniversityContext universityContext)
        {
            universityCont = universityContext;
        }

        public List<TraineeViewModel> Trainees()
        {
            return universityCont.Trainees.Select(x => new TraineeViewModel
            {
                TraineeName = x.Name,
                TraineeAddress = x.Address,
                TraineeId = x.Id,
                TraineeImag = x.Imag,
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
        public Trainee_CourseViewModel SpecificTraineeGradePerCourse(int Cid, int Tid)
        {
            return AllTraineeswithCourses().Where(c => (c.CID == Cid && c.TID == Tid)).SingleOrDefault()?? new Trainee_CourseViewModel();
        }
        public List<Trainee_CourseViewModel> TraineeAllCoursesGrades(int Tid)
        {
            return AllTraineeswithCourses().Where(t => t.TID == Tid).ToList();
        }

    }
}
