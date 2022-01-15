using eCademiaApp.Business.Abstract;
using eCademiaApp.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace eCademiaApp.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet("getById")]
        public IActionResult GetById(int id)
        {
            var result = _courseService.GetById(id);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = _courseService.GetAll();
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getCourseDetails")]
        public IActionResult GetCarDetails()
        {
            var result = _courseService.GetCourseDetails();
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getCoursesByTypeId")]
        public IActionResult GetCarsByBrandId(int typeId)
        {
            var result = _courseService.GetCoursesByTypeId(typeId);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getCoursesByInstructorId")]
        public IActionResult GetCoursesByInstructorId(int instructorId)
        {
            var result = _courseService.GetCoursesByInstructorId(instructorId);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }


        [HttpPost("add")] 
        public IActionResult Add(Course course)
        {
            var result = _courseService.Add(course);
            if (result.Success) return Ok(result); // TODO : 201 Created

            return BadRequest(result);
        }

        [HttpPut("update")] //HttpPost
        public IActionResult Update(Course course)
        {
            var result = _courseService.Update(course);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete("delete")] //HttpPost
        public IActionResult Delete(Course course)
        {
            var result = _courseService.Delete(course);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }
    }
}
