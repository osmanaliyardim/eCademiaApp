using eCademiaApp.Business.Abstract;
using eCademiaApp.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace eCademiaApp.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        // Injectable service
        private readonly ICourseService _courseService;

        // Injecting our services to establish a loosely coupled connection
        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        /// <summary>This method returns a specific course by id.</summary>
        /// <param name="id">course id</param>
        [HttpGet("getById")]
        public IActionResult GetById(int id)
        {
            var result = _courseService.GetById(id);
            if (result.Success) return Ok(result);

            return BadRequest(result.Message);
        }

        /// <summary>This method returns all courses.</summary>
        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = _courseService.GetAll();
            if (result.Success) return Ok(result);

            return BadRequest(result.Message);
        }

        /// <summary>This method returns a specific course details.</summary>
        [HttpGet("getCourseDetails")]
        public IActionResult GetCourseDetails()
        {
            var result = _courseService.GetCourseDetails();
            if (result.Success) return Ok(result);

            return BadRequest(result.Message);
        }

        /// <summary>This method returns specific courses by id.</summary>
        /// <param name="id">instructor id</param>
        [HttpGet("getCoursesByInstructorId")]
        public IActionResult GetCoursesByInstructorId(int instructorId)
        {
            var result = _courseService.GetCoursesByInstructorId(instructorId);
            if (result.Success) return Ok(result);

            return BadRequest(result.Message);
        }

        /// <summary>This method saves a new course to DB.</summary>
        /// <param name="Course">course object</param>
        [HttpPost("add")] 
        public IActionResult Add(Course course)
        {
            var result = _courseService.Add(course); 
            if (result.Success) return Created("", result.Message); // Ok(result.Message);

            return BadRequest(result.Message);
        }

        /// <summary>This method updates a specific course from DB.</summary>
        /// <param name="Course">course object</param>
        [HttpPost("update")]
        public IActionResult Update(Course course)
        {
            var result = _courseService.Update(course);
            if (result.Success) return Ok(result.Message);

            return BadRequest(result.Message);
        }

        /// <summary>This method removes a specific course from DB.</summary>
        /// <param name="Course">course object</param>
        [HttpPost("delete")]
        public IActionResult Delete(Course course)
        {
            var result = _courseService.Delete(course);
            if (result.Success) return Ok(result.Message);

            return BadRequest(result.Message);
        }
    }
}
