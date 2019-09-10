using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CoreFitness.Models;
using CoreFitness.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreFitness.Controllers
{
    [Authorize(Roles = "admin")]
    public class ProductsController : Controller
    {

        private readonly IProductRepository _productsRepository;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly AppDbContext context;

        public ProductsController(IProductRepository productsRepository, 
                                IHostingEnvironment hostingEnvironment,
                                AppDbContext context)
        {
            _productsRepository = productsRepository;
            this.hostingEnvironment = hostingEnvironment;
            this.context = context;
        }

        // Fetch and Display a list of all the products
        [HttpGet]
        [AllowAnonymous]
        public ViewResult Index()
        {
            var model = _productsRepository.GetProducts();
            return View(model);
        }

        // Display product details 
        [HttpGet]
        [AllowAnonymous]    
        public ViewResult ProductDetails(int id)
        {

            Product product = _productsRepository.GetProduct(id);

            if(product == null)
            {
                Response.StatusCode = 404;
                return View("ProductNotFound");
            }


            ProductDetailsViewModel productDetailsViewModel = new ProductDetailsViewModel()
            {
                Product = product,
                PageTitle = "Product Details"
            };

            return View(productDetailsViewModel);
        }


        // Display Add Product Form
        public ViewResult AddProduct()
        {
            return View();
        }

        // Add new product
        [HttpPost]
        public IActionResult AddProduct(ProductAddViewModel model)
        {

            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFile(model);
                

                Product newProduct = new Product
                {
                    Name = model.Name,
                    Description = model.Description,
                    Price = model.Price,
                    Availability = model.Availability,
                    ImageURL = uniqueFileName
                };

                _productsRepository.Add(newProduct);

                return RedirectToAction("index", new { id = newProduct.Id });
            }

            return View();
        }
        


        // Get form with current product values
        [HttpGet]
        public ViewResult EditProduct(int id)
        {

            Product product = _productsRepository.GetProduct(id);

            ProductEditViewModel productEditViewModel = new ProductEditViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Availability = product.Availability,
                ExistingPhotoPath = product.ImageURL
            };

            return View(productEditViewModel);
        }

        // Post changes to the product
        [HttpPost]
        public IActionResult EditProduct(ProductEditViewModel model)
        {

            if (ModelState.IsValid)
            {

                Product product = _productsRepository.GetProduct(model.Id);
                product.Name = model.Name;
                product.Description = model.Description;
                product.Price = model.Price;
                product.Availability = model.Availability;

                if(model.Photo != null)
                {
                    if(model.ExistingPhotoPath != null)
                    {
                        string filePath = Path.Combine(hostingEnvironment.WebRootPath,
                            "images", model.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                    product.ImageURL = ProcessUploadedFile(model);
                } 

                _productsRepository.Update(product);

                return RedirectToAction("index");
            }

            return View();
        }



        // Delete a product
        public IActionResult DeleteProduct(int id)
        {

            Product product = _productsRepository.GetProduct(id);

            string filePath = Path.Combine(hostingEnvironment.WebRootPath,
                            "images", product.ImageURL);
            // Delete Product from database
            _productsRepository.Delete(id);
            // Delete File from server
            System.IO.File.Delete(filePath);

            return RedirectToAction("index");
        }

        
        private string ProcessUploadedFile(ProductAddViewModel model)
        {
            string uniqueFileName = null;
            if (model.Photo != null)
            {
                
                // Get path of the wwwroot folder using HostingEnvornment 
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                // Append a unique guid value and a dash to the file name
                uniqueFileName = Guid.NewGuid().ToString() + "-" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                // Create File stream 
                FileStream fileStream = new FileStream(filePath, FileMode.Create);
                // Use CopyTo() method provided by IFormFile interface to
                // copy the file to wwwroot/images folder
                model.Photo.CopyTo(fileStream);
                // Close File Stream
                fileStream.Close();
            }

            return uniqueFileName;
        }



        // Add Product to shopping cart 
        [AllowAnonymous]
        public IActionResult AddToCart (int id, int qty)
        {
            Product product = context.Products.Find(id);

            if(product != null) {
                ShoppingCart shoppingCart = new ShoppingCart
                {
                    ProductName = product.Name,
                    ProductPrice = product.Price,
                    ProductQuantity = qty
                };
                _productsRepository.AddToCart(shoppingCart);
            }

            return RedirectToAction("index");
        }

        [AllowAnonymous]
        public async Task<IActionResult> SearchProduct(string SearchString)
        {
            var model = from m in context.Products
                         select m;

            if (!String.IsNullOrEmpty(SearchString))
            {
                model = model.Where(s => s.Name.Contains(SearchString));
            }

            return View("Index", await model.ToListAsync());
        }

    }

    
}