using backend.DataService;
using backend.Models;

namespace backend.BusinessService
{
    public class StudentBusinessService
    {
        private StudentDataService _studentDataService;

        public StudentBusinessService(StudentDataService studentDataService)
        {
            _studentDataService = studentDataService;
        }

        public List<Student> GetStudents()
        {
            return _studentDataService.GetStudents();
        }

        public Student? GetStudentById(long id)
        {
            return _studentDataService.GetStudentById(id);
        }

        public Student? GetStudentByCode(string studentCode)
        {
            return _studentDataService.GetStudentByCode(studentCode);
        }

        public long GetStudentId(string studentCode)
        {
            return _studentDataService.GetStudentId(studentCode);
        }

        public Student CreateStudent(Student student)
        {
            return _studentDataService.CreteStudent(student);
        }

        public Student UpdateStudent(Student student)
        {
            return _studentDataService.UpdateStudent(student);
        }

        public void DeleteStudent(long id)
        {
            _studentDataService.DeleteStudent(id);
        }
    }
}