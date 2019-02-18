using DataService.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using IO = System.IO.File;

namespace DataService.AgentDataService
{
    public class AgentDataService : IAgentDataService
    {
        private readonly string _path = string.Empty;
        public AgentDataService()
        {
            _path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\TestData\\agents.json";
        }
        public string AllAgents()
        {          
            return IO.ReadAllText(_path);
        }

        public string AgentDetails(int id)
        {   // data fetch below will change
            var agentData = IO.ReadAllText(_path);

            var agents = JsonConvert.DeserializeObject<List<Agent>>(agentData);
            var agent = agents.Find(agentDetails => agentDetails._id == id);

            return JsonConvert.SerializeObject(agent);
        }


    }
}
