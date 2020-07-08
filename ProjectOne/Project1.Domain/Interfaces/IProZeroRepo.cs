using System;
using System.Collections.Generic;

namespace Project1.Domain.Interfaces
{
    public interface IProZeroRepo
    {
        public IEnumerable<Model.Customer> GetCustomers(string search = null);
        public Model.Customer GetCustomerById(int id);
        public void AddCustomer(Model.Customer customer);
        public void RemoveCustomer(Model.Customer customer);

        void Save();
    }
}
