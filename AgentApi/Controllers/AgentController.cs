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

        [HttpGet("AllAgents")]
        public IActionResult All()
        {
            return Ok(_agentDataService.AllAgents());
        }

        [HttpGet("AgentDetails")]
        public IActionResult Details(int id)
        {
            return Ok(_agentDataService.AgentDetails(id));
        }

        [HttpPost("AddAgent")]
        public IActionResult AddAgent(string data)
        {
            return Ok(_agentDataService.AddAgent(data));
        }

        [HttpDelete("DeleteAgent")]
        public IActionResult DeleteAgent(int id)
        {
            return Ok(_agentDataService.DeleteAgent(id));
        }

        [HttpPut("UpdateAgent")]
        public IActionResult UpdateAgent(string data)
        {
            return Ok(_agentDataService.UpdateAgent(data));
        }
    }
}
