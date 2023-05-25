using backend.DataService;
using backend.Models;

namespace backend.BusinessService
{
    public class CourseBusinessService
    {
        private CourseDataService _courseDataService;

        public CourseBusinessService(CourseDataService courseDataService)
        {
            _courseDataService = courseDataService;
        }

        public List<Course> GetCourses()
        {
            return _courseDataService.GetCourses();
        }

        public Course CreateCourse(Course course)
        {
            return _courseDataService.CreateCourse(course);
        }
    }
}