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

            Model.Customer entity = Mapper.MapCustomer(customer);
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
            var customer = _dbContext.Customer
                .FirstOrDefault(c => c.CustomerId == id);
            return customer;
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
            IEnumerable<Project1.Domain.Model.Customer> customers;
            

            if (search != null)
            {
                customers = _dbContext.Customer.Select(c => c)
                    .Where(c => (c.FirstName.Contains(search) || c.LastName.Contains(search) || c.Email.Contains(search)))
                    .AsNoTracking();
               
            } else
            {
                customers = _dbContext.Customer;
            }
            

            return customers;
        }

        public IEnumerable<Project1.Domain.Model.Inventory> GetInventories(string search = null)
        {
            IEnumerable<Project1.Domain.Model.Inventory> inventories = _dbContext.Inventory;
            if (search != null)
            {
                // Why can a product have an inventory?
                inventories = inventories.Where(i => i.Product.Name.Contains(search));
            }
            return inventories;
        }

        public Project1.Domain.Model.Inventory GetInventoryById(int id)
        {
            throw new NotImplementedException();
        }

        //public Project1.Domain.Model.StoreOrder GetOrderById(int id)
        //{
        //    //Project1.Domain.Model.StoreOrder storeOrder = _dbContext.StoreOrder
        //    //    .Select(c => c)
        //    //    .Where(c => c.OrderId == id);
        //    //.AsEnumerable()
        //    //.Where(c => c.OrderId == id)
        //    //.FirstOrDefault();
        //    //var ent = _dbContext.OrderHistory
        //    //    .Where(o => o.OrderId == id)
        //    //    .First();
        //    throw new NotImplementedException();
        //    return  new Project1.Domain.Model.StoreOrder(); //storeOrder ??
        //}

        public IEnumerable<Project1.Domain.Model.OrderHistory> GetOrderHistory(string search = null)
        {
            if(search != null)
            {
                return _dbContext.OrderHistory
                    .Where(oh => oh.Customer.FirstName.Contains(search) 
                    || oh.Customer.LastName.Contains(search)
                    || oh.Customer.Email.Contains(search));
            }
            return _dbContext.OrderHistory;
        }

        public Project1.Domain.Model.OrderHistory GetOrderHistoryById(int id)
        {
            return _dbContext.OrderHistory.First(o => o.OrderId == id);
        }

        public IEnumerable<Project1.Domain.Model.StoreOrder> GetOrderIds()
        {
            IEnumerable<Project1.Domain.Model.StoreOrder> orders = _dbContext.StoreOrder
                .Select(x => new StoreOrder{Amount = x.Amount, OrderId = x.OrderId, ProductId = x.ProductId })
                .Select(Mapper.MapStoreOrder);


            return orders;
        }

        public Project1.Domain.Model.Product GetProductById(int id)
        {
            return _dbContext.Product.First(p => p.ProductId == id);
        }

        public IEnumerable<Project1.Domain.Model.Product> GetProducts(string search = null)
        {
            IEnumerable<Project1.Domain.Model.Product> products;

            if(search != null && search.Length > 0)
            {
                products = _dbContext.Product.Where(p => p.Name.Contains(search));
            } else
            {
                products = _dbContext.Product;
            }

            return products;
        }

        public Project1.Domain.Model.StoreLocation GetStoreLocationById(int id)
        {
            return _dbContext.StoreLocation.First(l => l.LocationId == id);
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
            _logger.LogInformation("Saving changes to the database");
            _dbContext.SaveChanges();
        }

        public void UpdateCustomer(Project1.Domain.Model.Customer customer)
        {
            _logger.LogInformation("Updating customer with ID {customerId}", customer.CustomerId);

            // calling Update would mark every property as Modified.
            // this way will only mark the changed properties as Modified.
            Project1.Domain.Model.Customer entity = _dbContext.Customer.First(c => c.CustomerId == customer.CustomerId);
            Model.Customer newEntity = Mapper.MapCustomer(entity);

            _dbContext.Entry(newEntity).CurrentValues.SetValues(customer);
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
