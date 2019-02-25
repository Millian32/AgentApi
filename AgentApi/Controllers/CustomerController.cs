using DataService.CustomerDataService;
using Microsoft.AspNetCore.Mvc;

namespace AgentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerDataService _customerDataService;

        public CustomerController(ICustomerDataService customerDataService)
        {
            _customerDataService = customerDataService;
        }

        [HttpGet("All")]
        public IActionResult AllCustomers()
        {
            var allCustomers = _customerDataService.AllCustomers();
            if (string.IsNullOrEmpty(allCustomers)) { return NotFound(); }

            return Ok(allCustomers);
        }

        [HttpGet("CustomerByAgent")]
        public IActionResult CustomerByAgent(int id)
        {
            if (id <= 0) { return BadRequest(); }
            var customer = _customerDataService.CustomerByAgent(id);
            if (string.IsNullOrEmpty(customer)) { return NotFound(); }

            return Ok(customer);
        }

        [HttpPost("Add")]
        public IActionResult AddCustomer(string data)
        {
            return Ok(_customerDataService.AddCustomer(data));
        }

        [HttpDelete("Delete")]
        public IActionResult DeleteCustomer(int id)
        {
            return Ok(_customerDataService.DeleteCustomer(id));
        }

        [HttpPut("Update")]
        public IActionResult UpdateCustomer(string data)
        {
            return Ok(_customerDataService.UpdateCustomer(data));
        }
    }
}