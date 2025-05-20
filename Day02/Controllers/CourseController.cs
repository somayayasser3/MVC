using Day02.BussinessLayer;
using Day02.Models;
using Day02.ViewModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Day02.Controllers
{
    public class CourseController: Controller
    {
        public CourseBL courseBl;
        public CourseController(CourseBL courseBl)
        {
            this.courseBl = courseBl;
        }

        public IActionResult Index()
        {
            List<CourseViewModel> courses = courseBl.AllCouses();
            if (courses == null)
            {
                return NotFound();
            }
            return View("Index", courses);
        }

        public IActionResult Results(int Cid, int Tid)
        {
            Trainee_CourseViewModel TCResults = courseBl.SpecificTraineeGradePerCourse(Cid, Tid);
            if (TCResults == null)
            {
                return NotFound();
            }
            return View("Results", TCResults);
        }

        public IActionResult Trainees(int id)
        {
            List<Trainee_CourseViewModel> TResults = courseBl.CourseAllTrainees(id);
            if (TResults == null)
            {
                return NotFound();
            }
            ViewBag.Imag = TResults.First().Imag;
            ViewBag.TraineeName = TResults.First().TraineeName;
            ViewBag.CourseName = TResults.First().CourseName;

            return View("Trainees", TResults);
        }

    }
}
