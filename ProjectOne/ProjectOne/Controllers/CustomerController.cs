using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project1.Domain.Interfaces;

namespace ProjectOne.Controllers
{
    public class CustomerController : Controller
    {
        public IProZeroRepo Repo { get; }

        public CustomerController(IProZeroRepo repo) =>
            Repo = repo ?? throw new ArgumentNullException(nameof(repo));

        public IActionResult Index()
        {
            return View();
        }
    }
}
