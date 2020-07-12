using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
//using ProjectOne.DataAccess.Interfaces;
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

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="customer"></param>
        public void AddCustomer(Project1.Domain.Model.Customer customer)
        {
            if (customer.CustomerId > 0)
                _logger.LogWarning("Customer to be added has an ID ({customerId}) already: ignoring.", customer.CustomerId);
            else
                _logger.LogInformation("Adding customer");

            Customer entity = Mapper.MapCustomer(customer);
            entity.CustomerId = 0;
            _dbContext.Add(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderHistory"></param>
        public void AddOrderHistory(Project1.Domain.Model.OrderHistory orderHistory)
        {
            throw new NotImplementedException();
        }

        public void CloseStore(Project1.Domain.Model.StoreLocation location)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get Customer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Project1.Domain.Model.Customer GetCustomerById(int id)
        {
            Customer customer = _dbContext.Customer
                .Include(c => c.FirstName != null && c.LastName != null)
                .FirstOrDefault(c => c.CustomerId == id);
            return Mapper.MapCustomer(customer);
        }

        public IEnumerable<Project1.Domain.Model.StoreOrder> GetCustomerOrders(Project1.Domain.Model.Customer customer)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get Customers
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public IEnumerable<Project1.Domain.Model.Customer> GetCustomers(string search = null)
        {
            IQueryable<Customer> items = _dbContext.Customer
                .Include(c => c.CustomerId).AsNoTracking();

            if (search != null)
            {
                items = items.Where(c => c.FirstName.Contains(search) || c.LastName.Contains(search) || c.Email.Contains(search));
            }
            return items.Select(Mapper.MapCustomer);
        }

        public IEnumerable<Project1.Domain.Model.Inventory> GetInventories(string search = null)
        {
            IQueryable<Inventory> inventories = _dbContext.Inventory
                .Include(i => i.LocationId).AsNoTracking();
            if (search != null)
            {
                // Why can a product have an inventory?
                inventories = inventories.Where(i => i.Product.Name.Contains(search));
            }
            return inventories.Select(Mapper.MapInventory).Where(i => i != null);
        }

        public Project1.Domain.Model.Inventory GetInventoryById(int id)
        {
            throw new NotImplementedException();
        }

        public Project1.Domain.Model.StoreOrder GetOrderById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Project1.Domain.Model.OrderHistory> GetOrderHistory(string search = null)
        {
            throw new NotImplementedException();
        }

        public Project1.Domain.Model.OrderHistory GetOrderHistoryById(int id)
        {
            throw new NotImplementedException();
        }

        public Project1.Domain.Model.Product GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Project1.Domain.Model.Product> GetProducts(string search = null)
        {
            throw new NotImplementedException();
        }

        public Project1.Domain.Model.StoreLocation GetStoreLocationById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Project1.Domain.Model.StoreLocation> GetStoreLocations(string search = null)
        {
            throw new NotImplementedException();
        }

        public void OpenNewStore(Project1.Domain.Model.StoreLocation location)
        {
            throw new NotImplementedException();
        }

        public void PlaceOrder(Project1.Domain.Model.StoreOrder order)
        {
            throw new NotImplementedException();
        }

        public void RemoveCustomer(Project1.Domain.Model.Customer customer)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCustomer(Project1.Domain.Model.Customer customer)
        {
            throw new NotImplementedException();
        }

        public void UpdateInventory(Project1.Domain.Model.Inventory inventory)
        {
            throw new NotImplementedException();
        }

        public void UpdateStore(Project1.Domain.Model.StoreLocation location)
        {
            throw new NotImplementedException();
        }

        public void UpdateStoreInventory(Project1.Domain.Model.StoreLocation location, Project1.Domain.Model.Inventory inventory)
        {
            throw new NotImplementedException();
        }
    }

}
