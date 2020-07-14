﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project1.Domain.Model;


namespace ProjectOne.Controllers
{
    public class StoreLocationTempController : Controller
    {
        private readonly DataAccess.Model.ProZeroContext _context;

        public StoreLocationTempController(DataAccess.Model.ProZeroContext context)
        {
            _context = context;
        }

        // GET: StoreLocationTemp
        public async Task<IActionResult> Index()
        {
            return View(await _context.StoreLocation.ToListAsync());
        }

        // GET: StoreLocationTemp/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storeLocation = await _context.StoreLocation
                .FirstOrDefaultAsync(m => m.LocationId == id);
            if (storeLocation == null)
            {
                return NotFound();
            }

            return View(storeLocation);
        }

        // GET: StoreLocationTemp/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StoreLocationTemp/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LocationId,Name,Address")] StoreLocation storeLocation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(storeLocation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(storeLocation);
        }

        // GET: StoreLocationTemp/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storeLocation = await _context.StoreLocation.FindAsync(id);
            if (storeLocation == null)
            {
                return NotFound();
            }
            return View(storeLocation);
        }

        // POST: StoreLocationTemp/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LocationId,Name,Address")] StoreLocation storeLocation)
        {
            if (id != storeLocation.LocationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(storeLocation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StoreLocationExists(storeLocation.LocationId))
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
            return View(storeLocation);
        }

        // GET: StoreLocationTemp/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storeLocation = await _context.StoreLocation
                .FirstOrDefaultAsync(m => m.LocationId == id);
            if (storeLocation == null)
            {
                return NotFound();
            }

            return View(storeLocation);
        }

        // POST: StoreLocationTemp/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var storeLocation = await _context.StoreLocation.FindAsync(id);
            _context.StoreLocation.Remove(storeLocation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StoreLocationExists(int id)
        {
            return _context.StoreLocation.Any(e => e.LocationId == id);
        }
    }
}
