using eCademiaApp.Business.Abstract;
using eCademiaApp.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace eCademiaApp.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        // Injectable service
        private readonly ICustomerService _customerService;

        // Injecting our services to establish a loosely coupled connection
        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        /// <summary>This method returns a specific customer by id.</summary>
        /// <param name="id">customer id</param>
        [HttpGet("getById")]
        public IActionResult GetById(int id)
        {
            var result = _customerService.GetById(id);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        /// <summary>This method returns all customers.</summary>
        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = _customerService.GetAll();
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        /// <summary>This method saves a new customer to DB.</summary>
        /// <param name="Customer">customer object</param>
        [HttpPost("add")]
        public IActionResult Add(Customer customer)
        {
            var result = _customerService.Add(customer);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        /// <summary>This method updates a specific customer from DB.</summary>
        /// <param name="Customer">customer object</param>
        [HttpPost("update")]
        public IActionResult Update(Customer customer)
        {
            var result = _customerService.Update(customer);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        /// <summary>This method removes a specific customer from DB.</summary>
        /// <param name="Customer">customer object</param>
        [HttpPost("delete")]
        public IActionResult Delete(Customer customer)
        {
            var result = _customerService.Delete(customer);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }
    }
}
