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
            IEnumerable<Project1.Domain.Model.StoreOrder> allOrders = Repo.GetOrders();
            //IEnumerable<Project1.Domain.Model.OrderHistory> histories = Repo.GetOrderHistory();
            //List<int> orderIds = allOrders.Select(a => a.OrderId).ToList();
            List<OrderHistoryViewModel> viewModels = new List<OrderHistoryViewModel>();

            foreach(Project1.Domain.Model.StoreOrder idos in allOrders.ToList())
            {
                var history = Repo.GetOrderHistoryById(idos.OrderId);
                var customer = history.Customer;
                //var customer = Repo.GetCustomerById(history.CustomerId ?? default);
                viewModels.Add(new OrderHistoryViewModel
                {
                    DateAndTime = history.Date.Add(history.Time),
                    Customer = new CustomerViewModel{
                        FirstName = customer.FirstName, LastName = customer.LastName, Email = customer.Email
                    },
                    StoreOrder = history.StoreOrder.Select(s => new StoreOrderViewModel()).Where(c => c.OrderId == history.OrderId),
                    CustomerId = customer.CustomerId,
                    Id = idos.OrderId,
                    Location = new StoreLocationViewModel {
                        Id=history.LocationId ?? default,
                        OrderHistory = new List<OrderHistoryViewModel>(),
                        Address = history.Location.Address,
                        Name = history.Location.Name,
                        Inventory = history.Location.Inventory.Select(x => new InventoryViewModel())
                    },
                    LocationId = history.LocationId
                });
            }

            return View(viewModels);
        }

        public ActionResult CustomerOrders([FromRoute]int id, [FromQuery] string search = "")
        {
            //IEnumerable<Project1.Domain.Model.StoreOrder> allOrders = Repo.GetOrders();
            Project1.Domain.Model.OrderHistory history = Repo.GetOrderHistoryById(id);
            List<OrderHistoryViewModel> viewModels = new List<OrderHistoryViewModel>();
           
            var customer = history.Customer;
            //var customer = Repo.GetCustomerById(history.CustomerId ?? default);
            viewModels.Add(new OrderHistoryViewModel
            {
                DateAndTime = history.Date.Add(history.Time),
                Customer = new CustomerViewModel
                {
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Email = customer.Email
                },
                StoreOrder = history.StoreOrder.Select(s => new StoreOrderViewModel()).Where(c => c.OrderId == history.OrderId),
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
                LocationId = history.LocationId
            });

            return View(); //ToDo
            //return View(viewModels);
        }

        // GET: OrderHistoryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
