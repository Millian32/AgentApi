namespace DataService.CustomerDataService
{
    public interface ICustomerDataService
    {
        string AllCustomers();
        string CustomerByAgent(int id);
        string AddCustomer(string data);
        string DeleteCustomer(int id);
        string UpdateCustomer(string data);
    }
}