//using ProjectOne.DataAccess.Model;

using System.Collections.Generic;
using Project1.Domain.Model;

namespace Project1.Domain.Interfaces
{
    public interface IProZeroRepo
    {
        // Customer
        IEnumerable<Customer> GetCustomers(string search = null);
        Customer GetCustomerById(int id);
        void AddCustomer(Customer customer);
        void RemoveCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        //

        // Inventory
        IEnumerable<Inventory> GetInventories(string search = null);
        Inventory GetInventoryById(int id);
        void UpdateInventory(Inventory inventory);
        //

        // Order History
        IEnumerable<OrderHistory> GetOrderHistory(string search = null);
        OrderHistory GetOrderHistoryById(int id);
        void AddOrderHistory(OrderHistory orderHistory);
        //

        // Product
        IEnumerable<Product> GetProducts(string search = null);
        Product GetProductById(int id);
        //

        // Store Location
        IEnumerable<StoreLocation> GetStoreLocations(string search = null);
        StoreLocation GetStoreLocationById(int id);
        void OpenNewStore(StoreLocation location);
        void CloseStore(StoreLocation location);
        void UpdateStore(StoreLocation location);
        void UpdateStoreInventory(StoreLocation location, Inventory inventory);
        //

        // Store Order
        IEnumerable<StoreOrder> GetOrderIds(); // Contains IDs
        IEnumerable<StoreOrder> GetCustomerOrders(Customer customer);
        //StoreOrder GetOrderById(int id);
        void PlaceOrder(StoreOrder order);
        //

        void Save();
    }
}
