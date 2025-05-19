using Day02.Models;
using Microsoft.AspNetCore.Mvc;

namespace Day02.Controllers
{
    public class InstructorController : Controller
    {
        public InstructorBl instructorBl;
        public InstructorController(InstructorBl instructorBl)
        {
            this.instructorBl = instructorBl;
        }
        public IActionResult Index()
        {

            List<InstructorInfo> InstructorBlList = instructorBl.GetAllInstructors();
            if(InstructorBlList is null)
                return NotFound();
            return View("Index",InstructorBlList);
        }

        public IActionResult Details(int id)
        {
            InstructorInfo instructor = instructorBl.GetInstructorByID(id);
            if(instructor == null)
            {
                return NotFound();
            }
            return View("Details", instructor);
        }
    }
}
