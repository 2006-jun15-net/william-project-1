using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project1.Domain.Interfaces;
using Project1.Domain.Model;
//using ProjectOne.ViewModels;

namespace ProjectOne.Controllers
{
    public class ProductController : Controller
    {
        public IProZeroRepo Repo { get; }

        public ProductController(IProZeroRepo repo) =>
            Repo = repo ?? throw new ArgumentNullException(nameof(repo));

        // GET: Product
        public ActionResult Index([FromQuery] string search = "")
        {
            var prods = Repo.GetProducts(search);
            //List<Product> products = new List<Product>();
            //foreach(Product prod in prods)
            //{
            //    products.Add(prod);
            //}

            return View(prods);
        }



        //// GET: Product/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var product = await _context.Product
        //        .FirstOrDefaultAsync(m => m.ProductId == id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(product);
        //}

        //// GET: Product/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Product/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Name,Price,ProductId")] Product product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(product);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(product);
        //}

        //// GET: Product/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var product = await _context.Product.FindAsync(id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(product);
        //}

        //// POST: Product/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Name,Price,ProductId")] Product product)
        //{
        //    if (id != product.ProductId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(product);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ProductExists(product.ProductId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(product);
        //}

        //private bool ProductExists(int id)
        //{
        //    return _context.Product.Any(e => e.ProductId == id);
        //}
    }
}
