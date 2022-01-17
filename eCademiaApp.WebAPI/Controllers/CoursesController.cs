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

            return BadRequest(result.Message);
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = _courseService.GetAll();
            if (result.Success) return Ok(result);

            return BadRequest(result.Message);
        }

        [HttpGet("getCourseDetails")]
        public IActionResult GetCarDetails()
        {
            var result = _courseService.GetCourseDetails();
            if (result.Success) return Ok(result);

            return BadRequest(result.Message);
        }

        [HttpGet("getCoursesByTypeId")]
        public IActionResult GetCarsByBrandId(int typeId)
        {
            var result = _courseService.GetCoursesByTypeId(typeId);
            if (result.Success) return Ok(result);

            return BadRequest(result.Message);
        }

        [HttpGet("getCoursesByInstructorId")]
        public IActionResult GetCoursesByInstructorId(int instructorId)
        {
            var result = _courseService.GetCoursesByInstructorId(instructorId);
            if (result.Success) return Ok(result);

            return BadRequest(result.Message);
        }


        [HttpPost("add")] 
        public IActionResult Add(Course course)
        {
            var result = _courseService.Add(course); 
            if (result.Success) return Created("", result.Message); // Ok(result.Message);

            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public IActionResult Update(Course course)
        {
            var result = _courseService.Update(course);
            if (result.Success) return Ok(result.Message);

            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Course course)
        {
            var result = _courseService.Delete(course);
            if (result.Success) return Ok(result.Message);

            return BadRequest(result.Message);
        }
    }
}
