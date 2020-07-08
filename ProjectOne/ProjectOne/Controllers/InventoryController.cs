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
    public class InventoryController : Controller
    {
        private readonly ProjectOneContext _context;

        public InventoryController(ProjectOneContext context)
        {
            _context = context;
        }

        // GET: Inventory
        public async Task<IActionResult> Index()
        {
            var projectOneContext = _context.InventoryViewModel.Include(i => i.Location).Include(i => i.Product);
            return View(await projectOneContext.ToListAsync());
        }

        // GET: Inventory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryViewModel = await _context.InventoryViewModel
                .Include(i => i.Location)
                .Include(i => i.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inventoryViewModel == null)
            {
                return NotFound();
            }

            return View(inventoryViewModel);
        }

        // GET: Inventory/Create
        public IActionResult Create()
        {
            ViewData["LocationId"] = new SelectList(_context.Set<StoreLocationViewModel>(), "Id", "Address");
            ViewData["ProductId"] = new SelectList(_context.Set<ProductViewModel>(), "Id", "Name");
            return View();
        }

        // POST: Inventory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Amount,Id,LocationId,ProductId")] InventoryViewModel inventoryViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inventoryViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocationId"] = new SelectList(_context.Set<StoreLocationViewModel>(), "Id", "Address", inventoryViewModel.LocationId);
            ViewData["ProductId"] = new SelectList(_context.Set<ProductViewModel>(), "Id", "Name", inventoryViewModel.ProductId);
            return View(inventoryViewModel);
        }

        // GET: Inventory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryViewModel = await _context.InventoryViewModel.FindAsync(id);
            if (inventoryViewModel == null)
            {
                return NotFound();
            }
            ViewData["LocationId"] = new SelectList(_context.Set<StoreLocationViewModel>(), "Id", "Address", inventoryViewModel.LocationId);
            ViewData["ProductId"] = new SelectList(_context.Set<ProductViewModel>(), "Id", "Name", inventoryViewModel.ProductId);
            return View(inventoryViewModel);
        }

        // POST: Inventory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Amount,Id,LocationId,ProductId")] InventoryViewModel inventoryViewModel)
        {
            if (id != inventoryViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventoryViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventoryViewModelExists(inventoryViewModel.Id))
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
            ViewData["LocationId"] = new SelectList(_context.Set<StoreLocationViewModel>(), "Id", "Address", inventoryViewModel.LocationId);
            ViewData["ProductId"] = new SelectList(_context.Set<ProductViewModel>(), "Id", "Name", inventoryViewModel.ProductId);
            return View(inventoryViewModel);
        }

        // GET: Inventory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryViewModel = await _context.InventoryViewModel
                .Include(i => i.Location)
                .Include(i => i.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inventoryViewModel == null)
            {
                return NotFound();
            }

            return View(inventoryViewModel);
        }

        // POST: Inventory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inventoryViewModel = await _context.InventoryViewModel.FindAsync(id);
            _context.InventoryViewModel.Remove(inventoryViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InventoryViewModelExists(int id)
        {
            return _context.InventoryViewModel.Any(e => e.Id == id);
        }
    }
}
