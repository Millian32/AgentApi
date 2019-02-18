namespace DataService.CustomerDataService
{
    public interface ICustomerDataService
    {
        string AllCustomers();
        string CustomerByAgent(int id);
    }
}