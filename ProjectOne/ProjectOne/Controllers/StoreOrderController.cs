﻿using System;
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
    public class StoreOrderController : Controller
    {
        private readonly ProjectOneContext _context;

        public StoreOrderController(ProjectOneContext context)
        {
            _context = context;
        }

        // GET: StoreOrder
        public async Task<IActionResult> Index()
        {
            return View(await _context.StoreOrderViewModel.ToListAsync());
        }

        // GET: StoreOrder/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storeOrderViewModel = await _context.StoreOrderViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (storeOrderViewModel == null)
            {
                return NotFound();
            }

            return View(storeOrderViewModel);
        }

        // GET: StoreOrder/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StoreOrder/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Amount,ProductId,OrderId")] StoreOrderViewModel storeOrderViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(storeOrderViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(storeOrderViewModel);
        }

        // GET: StoreOrder/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storeOrderViewModel = await _context.StoreOrderViewModel.FindAsync(id);
            if (storeOrderViewModel == null)
            {
                return NotFound();
            }
            return View(storeOrderViewModel);
        }

        // POST: StoreOrder/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Amount,ProductId,OrderId")] StoreOrderViewModel storeOrderViewModel)
        {
            if (id != storeOrderViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(storeOrderViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StoreOrderViewModelExists(storeOrderViewModel.Id))
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
            return View(storeOrderViewModel);
        }

        // GET: StoreOrder/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storeOrderViewModel = await _context.StoreOrderViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (storeOrderViewModel == null)
            {
                return NotFound();
            }

            return View(storeOrderViewModel);
        }

        // POST: StoreOrder/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var storeOrderViewModel = await _context.StoreOrderViewModel.FindAsync(id);
            _context.StoreOrderViewModel.Remove(storeOrderViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StoreOrderViewModelExists(int id)
        {
            return _context.StoreOrderViewModel.Any(e => e.Id == id);
        }
    }
}
