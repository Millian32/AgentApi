using DataService.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using IO = System.IO.File;

namespace DataService.CustomerDataService
{
    public class CustomerDataService : ICustomerDataService
    {
        private readonly string _path  = string.Empty;

        public CustomerDataService()
        {   //Get the actual data, sources will change from file....
            _path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\TestData\\customers.json";
        }
        public string AllCustomers()
        {
            return IO.ReadAllText(_path);
        }

        public string CustomerByAgent(int id)
        {   
            var customers = JsonConvert.DeserializeObject<List<Customer>>(IO.ReadAllText(_path));

            var customer = customers.Find(customerDetails => customerDetails.agent_id == id);

            return JsonConvert.SerializeObject(customer);
        }
    }
}
