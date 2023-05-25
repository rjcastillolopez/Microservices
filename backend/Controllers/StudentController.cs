using Microsoft.AspNetCore.Mvc;
using backend.BusinessService;
using backend.Models;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController
    {
        private StudentBusinessService _studentBusinessService;

        public StudentController(StudentBusinessService studentBusinessService)
        {
            _studentBusinessService = studentBusinessService;
        }

        [HttpGet("[action]")]
        public List<Student> GetStudents()
        {
            return _studentBusinessService.GetStudents();
        }

        [HttpGet("[action]/{id}")]
        public Student? GetStudentById(long id)
        {
            return _studentBusinessService.GetStudentById(id);
        }

        [HttpGet("[action]/{studentCode}")]
        public Student? GetStudentByCode(string studentCode)
        {
            return _studentBusinessService.GetStudentByCode(studentCode);
        }

        [HttpGet("[action]/{studentCode}")]
        public long GetStudentId(string studentCode)
        {
            return _studentBusinessService.GetStudentId(studentCode);
        }

        [HttpPost("[action]")]
        public Student CreateStudent(Student student)
        {
            return _studentBusinessService.CreateStudent(student);
        }

        [HttpPut("[action]")]
        public Student UpdateStudent(Student student)
        {
            return _studentBusinessService.UpdateStudent(student);
        }

        [HttpDelete("[action]/{id}")]
        public void DeleteStudent(long id)
        {
            _studentBusinessService.DeleteStudent(id);
        }
        
    }
}