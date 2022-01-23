using eCademiaApp.Business.Abstract;
using eCademiaApp.Core.Utilities.Pagination;
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
        private readonly PaginationParameters _paginationParameters;

        // Injecting our services to establish a loosely coupled connection
        public CoursesController(ICourseService courseService, PaginationParameters paginationParameters)
        {
            _courseService = courseService;
            _paginationParameters = paginationParameters;  
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

        /// <summary>This method returns all courses with pagination.</summary>
        [HttpGet("getAllWithPagination")]
        public IActionResult GetAllWithPagination(int pageNumber)
        {
            _paginationParameters.PageNumber = pageNumber; 
            var result = _courseService.GetAllWithPagination(_paginationParameters);
            if (result.Success) return Ok(result);

            return BadRequest(result.Message);
        }

        /// <summary>This method returns all course details.</summary>
        [HttpGet("getCourseDetails")]
        public IActionResult GetCourseDetails()
        {
            var result = _courseService.GetCourseDetails();
            if (result.Success) return Ok(result);

            return BadRequest(result.Message);
        }

        /// <summary>This method returns all course details.</summary>
        [HttpGet("getCourseDetailsById")]
        public IActionResult GetCourseDetails(int id)
        {
            var result = _courseService.GetCourseDetailsById(id);
            if (result.Success) return Ok(result);

            return BadRequest(result.Message);
        }

        /// <summary>This method returns specific courses by instructorId.</summary>
        /// <param name="id">instructor id</param>
        [HttpGet("getCoursesByInstructorId")]
        public IActionResult GetCoursesByInstructorId(int instructorId)
        {
            var result = _courseService.GetCoursesByInstructorId(instructorId);
            if (result.Success) return Ok(result);

            return BadRequest(result.Message);
        }

        /// <summary>This method returns specific courses by typeId.</summary>
        /// <param name="typeId">type id</param>
        [HttpGet("getCoursesByTypeId")]
        public IActionResult GetCoursesByTypeId(int typeId, int pageNumber)
        {
            _paginationParameters.PageNumber = pageNumber;
            var result = _courseService.GetCoursesByTypeId(typeId, _paginationParameters);
            if (result.Success) return Ok(result);

            return BadRequest(result.Message);
        }

        /// <summary>This method saves a new course to DB.</summary>
        /// <param name="course">course object</param>
        [HttpPost("add")] 
        public IActionResult Add(Course course)
        {
            var result = _courseService.Add(course); 
            if (result.Success) return Created("", result.Message); // Ok(result.Message);

            return BadRequest(result.Message);
        }

        /// <summary>This method updates a specific course from DB.</summary>
        /// <param name="course">course object</param>
        [HttpPost("update")]
        public IActionResult Update(Course course)
        {
            var result = _courseService.Update(course);
            if (result.Success) return Ok(result.Message);

            return BadRequest(result.Message);
        }

        /// <summary>This method removes a specific course from DB.</summary>
        /// <param name="course">course object</param>
        [HttpPost("delete")]
        public IActionResult Delete(Course course)
        {
            var result = _courseService.Delete(course);
            if (result.Success) return Ok(result.Message);

            return BadRequest(result.Message);
        }
    }
}
