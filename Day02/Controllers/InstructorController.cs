using Day02.BussinessLayer;
using Day02.ViewModels;
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

            List<InstructorViewModel> AllInstructors= instructorBl.GetAllInstructors();
            if(AllInstructors is null)
                return NotFound();
            return View("Index",AllInstructors);
        }

        public IActionResult Details(int id)
        {
            InstructorViewModel instructor = instructorBl.GetInstructorByID(id);
            if(instructor == null)
            {
                return NotFound();
            }
            return View("Details", instructor);
        }
    }
}
