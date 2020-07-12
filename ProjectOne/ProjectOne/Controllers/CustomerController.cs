using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project1.Domain.Interfaces;
using Project1.Domain.Model;
using ProjectOne.ViewModels;

namespace ProjectOne.Controllers
{
    public class CustomerController : Controller
    {
        public IProZeroRepo Repo { get; }

        public CustomerController(IProZeroRepo repo) =>
            Repo = repo ?? throw new ArgumentNullException(nameof(repo));

        // GET: Customer
        public ActionResult Index([FromQuery] string search = "")
        {
            IEnumerable<Customer> customers = Repo.GetCustomers();
            List<CustomerViewModel> viewModels = new List<CustomerViewModel>();

            foreach (Customer customer in customers)
            {
                CustomerViewModel model = new CustomerViewModel()
                {
                    Id = customer.CustomerId,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Email = customer.Email,
                    OrderHistory = customer.OrderHistory.Select(o => new OrderHistoryViewModel())
                };
                viewModels.Add(model);
            }



            return View(viewModels);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            Customer customer = Repo.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }

            CustomerViewModel viewModel = new CustomerViewModel
            {
                Id = customer.CustomerId,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                OrderHistory = customer.OrderHistory.Select(o => new OrderHistoryViewModel())
            };

            return View(viewModel);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("FirstName,LastName,Email")] CustomerViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Repo.AddCustomer(new Customer
                    {
                        FirstName = viewModel.FirstName,
                        LastName = viewModel.LastName,
                        Email = viewModel.Email
                    });
                    Repo.Save();
                    return RedirectToAction(nameof(Index));
                }
                return View(viewModel);
            }
            catch
            {
                return View(viewModel);
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                Customer customer = Repo.GetCustomerById(id);

                var viewModel = new CustomerViewModel
                {
                    Id = customer.CustomerId,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Email = customer.Email
                };

                return View(viewModel);
            }
            catch
            {
                return NotFound();
            }
        }

        // POST: Customer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("FirstName,LastName,Email")] CustomerViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    Customer customer = Repo.GetCustomerById(id);
                    customer.FirstName = viewModel.FirstName ?? throw new DbUpdateConcurrencyException();
                    customer.LastName = viewModel.LastName ?? throw new DbUpdateConcurrencyException();
                    customer.Email = viewModel.Email ?? throw new DbUpdateConcurrencyException();
                    Repo.UpdateCustomer(customer);
                    Repo.Save();

                    return RedirectToAction(nameof(Index));
                }
                return View(viewModel);
            }
            catch (Exception)
            {
                return View(viewModel);
            }
        }

        // 
        // GET: Customer/Delete/5
        public ActionResult Delete()//int id)
        {
            //var customer = Repo.GetCustomerById(id);
            //if (customer == null)
            //{
            //    return NotFound();
            //}
            //var viewModel = new CustomerViewModel
            //{
            //    Id = customer.CustomerId,
            //    FirstName = customer.FirstName,
            //    LastName = customer.LastName,
            //    Email = customer.Email,
            //    OrderHistory = customer.OrderHistory.Select(x => new OrderHistoryViewModel())
            //};

            //return View(viewModel);
            return View();
        }

        // POST: Customer/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Customer customer = 
        //    _context.Customer.Remove(customer);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool CustomerExists(int id)
        {
            return Repo.GetCustomers().Any(e => e.CustomerId == id);
        }
    }
}
