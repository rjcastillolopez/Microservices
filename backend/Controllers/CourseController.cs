using Microsoft.AspNetCore.Mvc;
using backend.BusinessService;
using backend.Models;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController: ControllerBase
    {
        private CourseBusinessService _courseBusinessService;
        public CourseController(CourseBusinessService courseBusinessService){
            _courseBusinessService = courseBusinessService;
        }

        [HttpGet("[action]")]
        public List<Course> GetCourses(){
            return _courseBusinessService.GetCourses();
        }

        [HttpPost("[action]")]
        public Course CreateCourse(Course course){
            return _courseBusinessService.CreateCourse(course);
        }

    }
}