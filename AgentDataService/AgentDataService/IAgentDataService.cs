namespace DataService.AgentDataService
{
    public interface IAgentDataService
    {
        string AllAgents();
        string AgentDetails(int id);

    }
}