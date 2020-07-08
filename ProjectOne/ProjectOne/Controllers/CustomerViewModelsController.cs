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
    public class CustomerViewModelsController : Controller
    {
        private readonly ProjectOneContext _context;

        public CustomerViewModelsController(ProjectOneContext context)
        {
            _context = context;
        }

        // GET: CustomerViewModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.CustomerViewModel.ToListAsync());
        }

        // GET: CustomerViewModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerViewModel = await _context.CustomerViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customerViewModel == null)
            {
                return NotFound();
            }

            return View(customerViewModel);
        }

        // GET: CustomerViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustomerViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,Id,Email")] CustomerViewModel customerViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customerViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customerViewModel);
        }

        // GET: CustomerViewModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerViewModel = await _context.CustomerViewModel.FindAsync(id);
            if (customerViewModel == null)
            {
                return NotFound();
            }
            return View(customerViewModel);
        }

        // POST: CustomerViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FirstName,LastName,Id,Email")] CustomerViewModel customerViewModel)
        {
            if (id != customerViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customerViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerViewModelExists(customerViewModel.Id))
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
            return View(customerViewModel);
        }

        // GET: CustomerViewModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerViewModel = await _context.CustomerViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customerViewModel == null)
            {
                return NotFound();
            }

            return View(customerViewModel);
        }

        // POST: CustomerViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customerViewModel = await _context.CustomerViewModel.FindAsync(id);
            _context.CustomerViewModel.Remove(customerViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerViewModelExists(int id)
        {
            return _context.CustomerViewModel.Any(e => e.Id == id);
        }
    }
}
