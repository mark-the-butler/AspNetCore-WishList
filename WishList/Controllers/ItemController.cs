using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WishList.Data;
using WishList.Models;

namespace WishList.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();

            return Redirect("/Index");
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var itemToDelete = _context.Items.Single(i => i.Id == id);
            _context.Items.Remove(itemToDelete);
            _context.SaveChanges();

            return Redirect("/Index");
        }
    }
}
