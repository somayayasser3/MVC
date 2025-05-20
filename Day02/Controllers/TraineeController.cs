using Day02.BussinessLayer;
using Day02.Models;
using Day02.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Day02.Controllers
{
    public class TraineeController : Controller
    {

        public TraineeBL traineeBl;
        public TraineeController(TraineeBL traineeBl)
        {
            this.traineeBl = traineeBl;
        }
        public IActionResult Index()
        {
            return View("Index", traineeBl.Trainees());
        }

        public IActionResult Results(int Cid, int Tid)
        {
            Trainee_CourseViewModel TCResults = traineeBl.SpecificTraineeGradePerCourse(Cid, Tid);
            if (TCResults == null)
            {
                return NotFound();
            }
            return View("Results", TCResults);
        }

        public IActionResult Courses(int id)
        {
            List<Trainee_CourseViewModel> TResults = traineeBl.TraineeAllCoursesGrades(id);
            if (TResults == null)
            {
                return NotFound();
            }
            ViewBag.Imag = TResults.First().Imag;
            ViewBag.TraineeName = TResults.First().TraineeName;
            ViewBag.CourseName = TResults.First().CourseName;

            return View("Courses", TResults);
        }

    }
}
