using backend.Models;

namespace backend.DataService
{
    public class StudentDataService
    {
        private Context _context;
        public StudentDataService(Context context){
            _context = context;
        }

        public List<Student> GetStudents(){
            return _context.Students.ToList();
        }

        public Student? GetStudentById(long id){
            var student = _context.Students.FirstOrDefault(x => x.Id == id);
            if (student != null){
                return student;
            } else {
                return null;
            }
        }

        public Student? GetStudentByCode(string studentCode){
            var student = _context.Students.FirstOrDefault(x => x.StudentCode == studentCode);
            if (student != null){
                return student;
            } else {
                return null;
            }
        }

        public long GetStudentId(string studentCode){
            var student = _context.Students.FirstOrDefault(x => x.StudentCode == studentCode);
            if(student != null){
                return student.Id;
            }
            return 0;
        }

        public Student CreateStudent(Student student){
            _context.Students.Add(student);
            _context.SaveChanges();
            return student;
        }

        public Student UpdateStudent(Student student){
            _context.Students.Update(student);
            _context.SaveChanges();
            return student;
        }

        public void DeleteStudent(long id){
            var student = _context.Students.FirstOrDefault(x => x.Id == id);
            if(student != null){
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
        }
    }
}