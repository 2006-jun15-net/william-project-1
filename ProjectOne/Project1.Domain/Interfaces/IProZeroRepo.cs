using System;
using System.Collections.Generic;
using Project1.Domain.Model;

namespace Project1.Domain.Interfaces
{
    public interface IProZeroRepo
    {
        public IEnumerable<Customer> GetCustomers(string search = null);
        public Customer GetCustomerById(int id);
        public void AddCustomer(Customer customer);
        public void RemoveCustomer(Customer customer);

        void Save();
    }
}
