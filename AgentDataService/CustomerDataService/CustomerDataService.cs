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
            if (id <= 0) { return "unable to find!"; }

            var customers = JsonConvert.DeserializeObject<List<Customer>>(IO.ReadAllText(_path));
            var customer = customers.Find(customerDetails => customerDetails.agent_id == id);

            return JsonConvert.SerializeObject(customer);
        }

        public string AddCustomer(string data)
        {
            if (string.IsNullOrEmpty(data)) { return "unable to add!"; }

            var customerData = IO.ReadAllText(_path);
            var customers = JsonConvert.DeserializeObject<List<Customer>>(customerData);
            var customerToAdd = JsonConvert.DeserializeObject<Customer>(data);
            customers.Add(customerToAdd);

            var successCheck = CRUD.WriteConfigDataToFile(JsonConvert.SerializeObject(customers), _path);
            if (!successCheck) { return "Write Failed"; }

            return IO.ReadAllText(_path);
        }

        public string DeleteCustomer(int id)
        {
            if (id <= 0) { return "unable to delete!"; }

            var customerData = IO.ReadAllText(_path);
            var customers = JsonConvert.DeserializeObject<List<Customer>>(customerData);
            var customerToDelete = customers.Find(customer => customer._id == id);
            customers.Remove(customerToDelete);

            var successCheck = CRUD.WriteConfigDataToFile(JsonConvert.SerializeObject(customers), _path);
            if (!successCheck) { return "delete failed"; }

            return IO.ReadAllText(_path);
        }

        public string UpdateCustomer(string data)
        {
            if (string.IsNullOrEmpty(data)) { return "unable to update!"; }

            var incomingCustomer = JsonConvert.DeserializeObject<Customer>(data);
            var customerData = IO.ReadAllText(_path);
            var customers = JsonConvert.DeserializeObject<List<Customer>>(customerData);
            var existingCustomer = customers.Find(customer => customer._id == incomingCustomer._id);

            if (existingCustomer == null) { return "unable to find record to update!"; }

            customers.Remove(existingCustomer);
            customers.Add(incomingCustomer);

            var successCheck = CRUD.WriteConfigDataToFile(JsonConvert.SerializeObject(customers), _path);
            if (!successCheck) { return "Delete Failed"; }

            return IO.ReadAllText(_path);
        }
    }
}
