using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjectOne.DataAccess.Interfaces;
//using Project1.Domain.Interfaces;

using ProjectOne.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

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
        public void AddCustomer(Customer customer)
        {
            if (customer.CustomerId > 0)
                _logger.LogWarning("Customer to be added has an ID ({customerId}) already: ignoring.", customer.CustomerId);
            else
                _logger.LogInformation("Adding customer");

            //Customer entity = Mapper.MapCustomer(customer);
            customer.CustomerId = 0;
            _dbContext.Add(customer);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderHistory"></param>
        public void AddOrderHistory(OrderHistory orderHistory)
        {
            throw new NotImplementedException();
        }

        public void CloseStore(StoreLocation location)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StoreOrder> GetCustomerOrders(Customer customer)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get Customers
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public IEnumerable<Customer> GetCustomers(string search = null)
        {
            IEnumerable<Customer> items = _dbContext.Customer
                .Include(c => c.CustomerId).AsNoTracking();

            if(search != null)
            {
                items = items.Where(c => c.FirstName.Contains(search) || c.LastName.Contains(search) || c.Email.Contains(search) );
            }
            return items ?? new List<Customer>();
        }

        public IEnumerable<Inventory> GetInventories(string search = null)
        {
            IEnumerable<Inventory> inventories =  _dbContext.Inventory
                .Include(i => i.LocationId).AsNoTracking();
            if(search != null)
            {
                inventories = inventories.Where(i => i.Product.Name.Contains(search));
            }
            return inventories.Where(i => i != null);
        }

        public void OpenNewStore(StoreLocation location)
        {
            throw new NotImplementedException();
        }

        public void PlaceOrder(StoreOrder order)
        {
            throw new NotImplementedException();
        }

        public void RemoveCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void UpdateInventory(Inventory inventory)
        {
            throw new NotImplementedException();
        }

        public void UpdateStore(StoreLocation location)
        {
            throw new NotImplementedException();
        }

        public void UpdateStoreInventory(StoreLocation location, Inventory inventory)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomerById(int id)
        {
            Customer customer = _dbContext.Customer
                .Include(c => c.FirstName != null && c.LastName != null)
                .FirstOrDefault(c => c.CustomerId == id);
            return customer;
        }

        public Inventory GetInventoryById(int id)
        {
            throw new NotImplementedException();
        }

        public StoreOrder GetOrderById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderHistory> GetOrderHistory(string search)
        {
            throw new NotImplementedException();
        }

        public OrderHistory GetOrderHistoryById(int id)
        {
            throw new NotImplementedException();
        }

        public Product GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProducts(string search)
        {
            throw new NotImplementedException();
        }

        public StoreLocation GetStoreLocationById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StoreLocation> GetStoreLocations(string search)
        {
            throw new NotImplementedException();
        }
    }

}