using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project1.Domain.Model;
using ProjectOne.Data;

namespace ProjectOne.Controllers
{
    public class OrderHistoryController : Controller
    {
        private readonly ProjectOneContext _context;

        public OrderHistoryController(ProjectOneContext context)
        {
            _context = context;
        }

        // GET: OrderHistory
        public async Task<IActionResult> Index()
        {
            var projectOneContext = _context.OrderHistoryViewModel.Include(o => o.Customer).Include(o => o.Location);
            return View(await projectOneContext.ToListAsync());
        }

        // GET: OrderHistory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderHistoryViewModel = await _context.OrderHistoryViewModel
                .Include(o => o.Customer)
                .Include(o => o.Location)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderHistoryViewModel == null)
            {
                return NotFound();
            }

            return View(orderHistoryViewModel);
        }

        // GET: OrderHistory/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.CustomerViewModel, "Id", "Email");
            ViewData["LocationId"] = new SelectList(_context.Set<StoreLocationViewModel>(), "Id", "Address");
            return View();
        }

        // POST: OrderHistory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Date,Time,Id,CustomerId,LocationId")] OrderHistoryViewModel orderHistoryViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderHistoryViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.CustomerViewModel, "Id", "Email", orderHistoryViewModel.CustomerId);
            ViewData["LocationId"] = new SelectList(_context.Set<StoreLocationViewModel>(), "Id", "Address", orderHistoryViewModel.LocationId);
            return View(orderHistoryViewModel);
        }

        // GET: OrderHistory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderHistoryViewModel = await _context.OrderHistoryViewModel.FindAsync(id);
            if (orderHistoryViewModel == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.CustomerViewModel, "Id", "Email", orderHistoryViewModel.CustomerId);
            ViewData["LocationId"] = new SelectList(_context.Set<StoreLocationViewModel>(), "Id", "Address", orderHistoryViewModel.LocationId);
            return View(orderHistoryViewModel);
        }

        // POST: OrderHistory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Date,Time,Id,CustomerId,LocationId")] OrderHistoryViewModel orderHistoryViewModel)
        {
            if (id != orderHistoryViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderHistoryViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderHistoryViewModelExists(orderHistoryViewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.CustomerViewModel, "Id", "Email", orderHistoryViewModel.CustomerId);
            ViewData["LocationId"] = new SelectList(_context.Set<StoreLocationViewModel>(), "Id", "Address", orderHistoryViewModel.LocationId);
            return View(orderHistoryViewModel);
        }

        // GET: OrderHistory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderHistoryViewModel = await _context.OrderHistoryViewModel
                .Include(o => o.Customer)
                .Include(o => o.Location)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderHistoryViewModel == null)
            {
                return NotFound();
            }

            return View(orderHistoryViewModel);
        }

        // POST: OrderHistory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderHistoryViewModel = await _context.OrderHistoryViewModel.FindAsync(id);
            _context.OrderHistoryViewModel.Remove(orderHistoryViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderHistoryViewModelExists(int id)
        {
            return _context.OrderHistoryViewModel.Any(e => e.Id == id);
        }
    }
}
