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
            if (id <= 0) { return "unable to find record!"; }

            var agentData = IO.ReadAllText(_path);

            var agents = JsonConvert.DeserializeObject<List<Agent>>(agentData);
            var agent = agents.Find(agentDetails => agentDetails._id == id);

            return JsonConvert.SerializeObject(agent);
        }

        public string AddAgent(string data)
        {
            if (string.IsNullOrEmpty(data)) { return "unable to add!"; }

            var agentData = IO.ReadAllText(_path);
            var agents = JsonConvert.DeserializeObject<List<Agent>>(agentData);
            var agentToAdd = JsonConvert.DeserializeObject<Agent>(data);
            agents.Add(agentToAdd);

            var successCheck = CRUD.WriteConfigDataToFile(JsonConvert.SerializeObject(agents), _path);
            if (!successCheck) { return "write failed"; }

            return IO.ReadAllText(_path);
        }

        public string DeleteAgent(int id)
        {
            if (id <= 0) { return "unable to delete!"; }

            var agentData = IO.ReadAllText(_path);
            var agents = JsonConvert.DeserializeObject<List<Agent>>(agentData);
            var agentToDelete = agents.Find(agent => agent._id == id);
            agents.Remove(agentToDelete);

            var successCheck = CRUD.WriteConfigDataToFile(JsonConvert.SerializeObject(agents), _path);
            if (!successCheck) { return "delete failed"; }

            return IO.ReadAllText(_path);
        }

        public string UpdateAgent(string data)
        {
            if (string.IsNullOrEmpty(data)) { return "unable to update!"; }

            var incomingAgent = JsonConvert.DeserializeObject<Agent>(data);
            var agentData = IO.ReadAllText(_path);
            var agents = JsonConvert.DeserializeObject<List<Agent>>(agentData);
            var existingAgent = agents.Find(agent => agent._id == incomingAgent._id);

            if (existingAgent == null) { return "unable to find record to update!"; }

            agents.Remove(existingAgent);
            agents.Add(incomingAgent);

            var successCheck = CRUD.WriteConfigDataToFile(JsonConvert.SerializeObject(agents), _path);
            if (!successCheck) { return "update failed"; }

            return IO.ReadAllText(_path);
        }
    }
}
