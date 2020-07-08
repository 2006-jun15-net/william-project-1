using Microsoft.EntityFrameworkCore;
using Project1.Domain.Interfaces;
using ProjectOne.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectOne.DataAccess.Repositories
{

    public class ProZeroRepo : IProZeroRepo
    {
        private readonly ProZeroContext _dbContext;

        public ProZeroRepo(ProZeroContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void AddCustomer(Project1.Domain.Model.Customer customer)
        {
            throw new NotImplementedException();
        }

        public Project1.Domain.Model.Customer GetCustomerById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Project1.Domain.Model.Customer> GetCustomers(string search = null)
        {
            IQueryable<Customer> items = _dbContext.Customer
                .Include(c => c.CustomerId).AsNoTracking();

            return items;
        }

        public void RemoveCustomer(Project1.Domain.Model.Customer customer)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new System.NotImplementedException();
        }
    }

}