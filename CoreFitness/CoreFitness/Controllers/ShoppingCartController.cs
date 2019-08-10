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


        private readonly IShoppingCartRepository _shoppingCartRepository;
        public ShoppingCartController (IShoppingCartRepository shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }

        [HttpGet]
        public ViewResult Index()
        {

            var model = _shoppingCartRepository.GetShoppingCart();
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            _shoppingCartRepository.Delete(id);

            return RedirectToAction("index");

        }

    }
}