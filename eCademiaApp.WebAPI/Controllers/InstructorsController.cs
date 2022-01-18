using eCademiaApp.Entities.Concrete;
using eCademiaApp.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace eCademiaApp.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class InstructorsController : ControllerBase
    {
        // Injectable service
        private readonly IInstructorService _instructorService;

        // Injecting our services to establish a loosely coupled connection
        public InstructorsController(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }

        /// <summary>This method returns a specific instructor by id.</summary>
        /// <param name="id">instructor id</param>
        [HttpGet("getById")]
        public IActionResult GetById(int id)
        {
            var result = _instructorService.GetById(id);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        /// <summary>This method returns all instructors.</summary>
        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = _instructorService.GetAll();
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        /// <summary>This method saves a new instructor to DB.</summary>
        /// <param name="instructor">instructor object</param>
        [HttpPost("add")]
        public IActionResult Add(Instructor instructor)
        {
            var result = _instructorService.Add(instructor);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        /// <summary>This method updates a specific instructor from DB.</summary>
        /// <param name="instructor">instructor object</param>
        [HttpPost("update")]
        public IActionResult Update(Instructor instructor)
        {
            var result = _instructorService.Update(instructor);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        /// <summary>This method removes a specific instructor from DB.</summary>
        /// <param name="instructor">instructor object</param>
        [HttpPost("delete")]
        public IActionResult Delete(Instructor instructor)
        {
            var result = _instructorService.Delete(instructor);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }
    }
}
