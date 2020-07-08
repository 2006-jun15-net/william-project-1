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
    public class StoreLocationController : Controller
    {
        private readonly ProjectOneContext _context;

        public StoreLocationController(ProjectOneContext context)
        {
            _context = context;
        }

        // GET: StoreLocation
        public async Task<IActionResult> Index()
        {
            return View(await _context.StoreLocationViewModel.ToListAsync());
        }

        // GET: StoreLocation/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storeLocationViewModel = await _context.StoreLocationViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (storeLocationViewModel == null)
            {
                return NotFound();
            }

            return View(storeLocationViewModel);
        }

        // GET: StoreLocation/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StoreLocation/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Address")] StoreLocationViewModel storeLocationViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(storeLocationViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(storeLocationViewModel);
        }

        // GET: StoreLocation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storeLocationViewModel = await _context.StoreLocationViewModel.FindAsync(id);
            if (storeLocationViewModel == null)
            {
                return NotFound();
            }
            return View(storeLocationViewModel);
        }

        // POST: StoreLocation/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address")] StoreLocationViewModel storeLocationViewModel)
        {
            if (id != storeLocationViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(storeLocationViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StoreLocationViewModelExists(storeLocationViewModel.Id))
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
            return View(storeLocationViewModel);
        }

        // GET: StoreLocation/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storeLocationViewModel = await _context.StoreLocationViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (storeLocationViewModel == null)
            {
                return NotFound();
            }

            return View(storeLocationViewModel);
        }

        // POST: StoreLocation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var storeLocationViewModel = await _context.StoreLocationViewModel.FindAsync(id);
            _context.StoreLocationViewModel.Remove(storeLocationViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StoreLocationViewModelExists(int id)
        {
            return _context.StoreLocationViewModel.Any(e => e.Id == id);
        }
    }
}
