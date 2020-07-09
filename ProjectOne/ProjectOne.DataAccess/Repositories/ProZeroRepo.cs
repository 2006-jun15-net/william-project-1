using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<ProZeroRepo> _logger;

        public ProZeroRepo(ProZeroContext dbContext, ILogger<ProZeroRepo> logger)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
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

            // TODO: This code seems fishy. I'm going to try and find this line with SonarCloud
            return (IEnumerable<Project1.Domain.Model.Customer>)items;
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