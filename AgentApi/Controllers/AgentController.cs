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







        //// GET: api/Agent
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/Agent/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Agent
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/Agent/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
