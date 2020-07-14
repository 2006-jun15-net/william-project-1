using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project1.Domain.Interfaces;
using ProjectOne.DataAccess;
using ProjectOne.ViewModels;

namespace ProjectOne.Controllers
{
    public class OrderController : Controller
    {

        public IProZeroRepo Repo { get; }

        public OrderController(IProZeroRepo repo) =>
            Repo = repo ?? throw new ArgumentNullException(nameof(repo));


        // GET: OrderHistoryController
        public ActionResult Index([FromQuery] string search = "")
        {
            IEnumerable<Project1.Domain.Model.OrderHistory> histories = Repo.GetOrderHistory();

            List<OrderHistoryViewModel> viewModels = new List<OrderHistoryViewModel>();

            foreach(Project1.Domain.Model.OrderHistory hist in histories.ToList())
            {
                var customer = Repo.GetCustomerById(hist.CustomerId ?? default);
                var location = Repo.GetStoreLocationById(hist.LocationId ?? default);
                var order = Repo.GetOrderIds().First(o => o.OrderId == hist.OrderId);
                var product = Repo.GetProductById(order.ProductId);

                viewModels.Add(new OrderHistoryViewModel
                {
                    DateAndTime = hist.Date.Add(hist.Time),
                    Customer = new CustomerViewModel{
                        FirstName = customer.FirstName, LastName = customer.LastName, Email = customer.Email
                    },
                    StoreOrder = new StoreOrderViewModel
                    {
                        Amount = order.Amount,
                        ProductId = order.ProductId,
                        OrderId = order.OrderId
                    },
                    CustomerId = customer.CustomerId,
                    Id = hist.OrderId,
                    Location = new StoreLocationViewModel {
                        Id= hist.LocationId ?? default,
                        OrderHistory = new List<OrderHistoryViewModel>(),
                        Address = location.Address,
                        Name = location.Name,
                        Inventory = hist.Location.Inventory.Select(x => new InventoryViewModel())
                    },
                    LocationId = hist.LocationId ?? default,
                    Product = product
                });
            }

            return View(viewModels);
        }

        public ActionResult CustomerOrders([FromRoute]int id, [FromQuery] string search = "")
        {
            Project1.Domain.Model.OrderHistory history = Repo.GetOrderHistoryById(id);
            List<OrderHistoryViewModel> viewModels = new List<OrderHistoryViewModel>();
            var order = Repo.GetOrderIds().First(o => o.OrderId == history.OrderId);
            var product = Repo.GetProductById(order.ProductId);
            var customer = history.Customer;

            viewModels.Add(new OrderHistoryViewModel
            {
                DateAndTime = history.Date.Add(history.Time),
                Customer = new CustomerViewModel
                {
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Email = customer.Email
                },
                StoreOrder = new StoreOrderViewModel
                {
                    Amount = order.Amount,
                    ProductId = order.ProductId,
                    OrderId = order.OrderId
                },
                CustomerId = customer.CustomerId,
                Id = id,
                Location = new StoreLocationViewModel
                {
                    Id = history.LocationId ?? default,
                    OrderHistory = new List<OrderHistoryViewModel>(),
                    Address = history.Location.Address,
                    Name = history.Location.Name,
                    Inventory = history.Location.Inventory.Select(x => new InventoryViewModel())
                },
                LocationId = history.LocationId,
                Product = product
            });

            /////// ToDo
            return View(viewModels);
        }

        // GET: OrderHistoryController/Details/5
        public ActionResult Details(int id)
        {
            Project1.Domain.Model.OrderHistory history = Repo.GetOrderHistoryById(id);

            List<OrderHistoryViewModel> viewModels = new List<OrderHistoryViewModel>();
           
            var customer = Repo.GetCustomerById(history.CustomerId ?? default);
            var location = Repo.GetStoreLocationById(history.LocationId ?? default);
            var order = Repo.GetOrderIds().First(o => o.OrderId == history.OrderId);
            var product = Repo.GetProductById(order.ProductId);

            viewModels.Add(new OrderHistoryViewModel
            {
                DateAndTime = history.Date.Add(history.Time),
                Customer = new CustomerViewModel
                {
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Email = customer.Email
                },
                StoreOrder = new StoreOrderViewModel { 
                    Amount = order.Amount,
                    ProductId = order.ProductId,
                    OrderId = order.OrderId
                },
                CustomerId = customer.CustomerId,
                Id = history.OrderId,
                Location = new StoreLocationViewModel
                {
                    Id = history.LocationId ?? default,
                    OrderHistory = new List<OrderHistoryViewModel>(),
                    Address = location.Address,
                    Name = location.Name,
                    Inventory = location.Inventory.Select(x => new InventoryViewModel())
                },
                LocationId = history.LocationId ?? default,
                Product = product
            }); ;

            return View(viewModels);
        }

        // GET: OrderHistoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderHistoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderHistoryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderHistoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderHistoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderHistoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
