namespace DataService.AgentDataService
{
    public interface IAgentDataService
    {
        string AllAgents();
        string AgentDetails(int id);
        string AddAgent(string agent);
        string DeleteAgent(int id);
        string UpdateAgent(string data);
    }
}