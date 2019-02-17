using Newtonsoft.Json;
using System.IO;
using System.Reflection;
using IO = System.IO.File;

namespace AgentData
{
    public class AgentDataService : IAgentDataService
    {
        public string GetAllAgents()
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\TestData\\agents.json";

            var contents = IO.ReadAllText(path);

            var returnData = JsonConvert.DeserializeObject(contents);

            return returnData.ToString();
        }
    }
}
