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
        public string AllAgents()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\TestData\\agents.json";

            return IO.ReadAllText(path);
        }

        public string AgentDetails(int id)
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\TestData\\agents.json";
            var contents = IO.ReadAllText(path);
            var agents = JsonConvert.DeserializeObject<List<Agent>>(contents);

            var agent = agents.Find(agentDetails => agentDetails._id == id);

            return JsonConvert.SerializeObject(agent);
        }


    }
}
