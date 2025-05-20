using Day02.Models;
using Day02.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Day02.BussinessLayer
{
    public class InstructorBl
    {
        public UniversityContext universityCont;
        public InstructorBl(UniversityContext universityContext)
        {
            universityCont = universityContext;
        }

        public List<InstructorViewModel> GetAllInstructors()
        {
            return universityCont.Instructors
                    .Select(i => new InstructorViewModel
                    {
                        Id = i.Id,
                        InstructorName = i.Name,
                        Salary = i.Salary,
                        Address = i.Address,
                        CourseName = i.course.Name,
                        DepartmentName = i.department.Name,
                        InstructorImag = i.Imag
                    }).ToList();
        }

        public InstructorViewModel GetInstructorByID(int id)
        {
            return universityCont.Instructors
                    .Where(i => i.Id == id)
                    .Select(i => new InstructorViewModel
                    {
                        Id = i.Id,
                        InstructorName = i.Name,
                        Salary = i.Salary,
                        Address = i.Address,
                        CourseName = i.course.Name,
                        DepartmentName = i.department.Name,
                        InstructorImag = i.Imag
                    }).SingleOrDefault() ?? new InstructorViewModel();
        }
    }
}
