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

        [HttpGet("AllCustomers")]
        public IActionResult AllCustomers()
        {
            return Ok(_customerDataService.AllCustomers());
        }

        [HttpGet("CustomerByAgent")]
        public IActionResult CustomerByAgent(int id)
        {
            return Ok(_customerDataService.CustomerByAgent(id));
        }
    }
}