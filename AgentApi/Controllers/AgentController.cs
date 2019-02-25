using DataService.AgentDataService;
using Microsoft.AspNetCore.Mvc;

namespace AgentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        private readonly IAgentDataService _agentDataService;

        public AgentController(IAgentDataService agentDataService)
        {
            _agentDataService = agentDataService;
        }

        [HttpGet("All")]
        public IActionResult AllAgents()
        {
            var allAgents = _agentDataService.AllAgents();
            if (string.IsNullOrEmpty(allAgents)) { return NotFound(); }

            return Ok();
        }

        [HttpGet("Details")]
        public IActionResult Details(int id)
        {
            return Ok(_agentDataService.AgentDetails(id));
        }

        [HttpPost("Add")]
        public IActionResult AddAgent(string data)
        {
            return Ok(_agentDataService.AddAgent(data));
        }

        [HttpDelete("Delete")]
        public IActionResult DeleteAgent(int id)
        {
            return Ok(_agentDataService.DeleteAgent(id));
        }

        [HttpPut("Update")]
        public IActionResult UpdateAgent(string data)
        {
            return Ok(_agentDataService.UpdateAgent(data));
        }
    }
}
