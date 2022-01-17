using eCademiaApp.Entities.Concrete;
using eCademiaApp.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace eCademiaApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorsController : ControllerBase
    {
        private readonly IInstructorService _instructorService;

        public InstructorsController(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _instructorService.GetById(id);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _instructorService.GetAll();
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Instructor instructor)
        {
            var result = _instructorService.Add(instructor);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Instructor instructor)
        {
            var result = _instructorService.Update(instructor);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Instructor instructor)
        {
            var result = _instructorService.Delete(instructor);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }
    }
}
