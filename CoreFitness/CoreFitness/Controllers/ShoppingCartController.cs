using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreFitness.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreFitness.Controllers
{
    public class ShoppingCartController : Controller
    {


        
        private readonly AppDbContext context;

        public ShoppingCartController (AppDbContext context)
        {
            this.context = context;
        }

        // Display all items currently in the shopping cart 
        [HttpGet]
        public ViewResult Index()
        {

            var model = context.ShoppingCart;
            return View(model);
        }

        // Delete item from shopping cart
        public IActionResult Delete(int id)
        {
            ShoppingCart shoppingCart = context.ShoppingCart.Find(id);
            if (shoppingCart != null)
            {
                context.ShoppingCart.Remove(shoppingCart);
                context.SaveChanges();
            }

            return RedirectToAction("index");

        }

    }
}