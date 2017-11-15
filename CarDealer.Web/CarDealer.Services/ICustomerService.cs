namespace CarDealer.Services
{
    using CarDealer.Services.Models.Customers;
    using Models;
    using System;
    using System.Collections.Generic;

    public interface ICustomerService
    {
        IEnumerable<CustomerModel> OrderedCustomers(OrderDirection order);

        ByIdModel GetCustomer(int id);

        void Create(string name, DateTime birthdate, bool isYoungDriver);

        CustomerModel ById(int id);

        void Edit(int id, string name, DateTime birthdate, bool isYoungDriver);
    }
}
