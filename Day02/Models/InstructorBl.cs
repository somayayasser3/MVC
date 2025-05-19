using Microsoft.EntityFrameworkCore;

namespace Day02.Models
{
    public class InstructorBl
    {
        public UniversityContext universityCont;
        public InstructorBl(UniversityContext universityContext)
        {
            universityCont = universityContext;
        }

        public List<InstructorInfo> GetAllInstructors()
        {
            return universityCont.Instructors
                    .Include(i => i.course)
                    .Include(i => i.department)
                    .Select(i => new InstructorInfo
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

        public InstructorInfo GetInstructorByID(int id)
        {

            return universityCont.Instructors
                     .Include(i => i.course)
                     .Include(i => i.department)
                     .Where(i => i.Id == id)
                     .Select(i => new InstructorInfo
                     {
                         Id = i.Id,
                         InstructorName = i.Name,
                         Salary = i.Salary,
                         Address = i.Address,
                         CourseName = i.course.Name,
                         DepartmentName = i.department.Name,
                         InstructorImag = i.Imag
                     }).SingleOrDefault()??new InstructorInfo();

        }
    }
}
