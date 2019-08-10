using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CoreFitness.Models;
using CoreFitness.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace CoreFitness.Controllers
{
    public class ProductsController : Controller
    {

        private readonly IProductRepository _productsRepository;
        private readonly IHostingEnvironment hostingEnvironment;
        public ProductsController(IProductRepository productsRepository, 
                                IHostingEnvironment hostingEnvironment)
        {
            _productsRepository = productsRepository;
            this.hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public ViewResult Index()
        {
            var model = _productsRepository.GetProducts();
            return View(model);
        }

        [HttpGet]
        public ViewResult ProductDetails(int? id)
        {
            ProductDetailsViewModel productDetailsViewModel = new ProductDetailsViewModel()
            {
                Product = _productsRepository.GetProduct(id ?? 1),
                PageTitle = "Product Details"
            };


            return View(productDetailsViewModel);
        }

      
        public ViewResult AddProduct()
        {
            return View();
        }

        // POST
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

        public IActionResult DeleteProduct(int id)
        {
            _productsRepository.Delete(id);

            return RedirectToAction("index");
         
        }

        private string ProcessUploadedFile(ProductAddViewModel model)
        {
            string uniqueFileName = null;
            if (model.Photo != null)
            {
                // The image must be uploaded to the images folder in wwwroot
                // To get the path of the wwwroot folder we are using the inject
                // HostingEnvironment service provided by ASP.NET Core
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                // To make sure the file name is unique we are appending a new
                // GUID value and and an underscore to the file name
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
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


        public IActionResult AddToCart (int id)
        {
            Product product = _productsRepository.GetProduct(id);

            ShoppingCart shoppingCart = new ShoppingCart
            {
                ProductName = product.Name,
                ProductPrice = product.Price

            };

            _productsRepository.AddToCart(shoppingCart);

            return RedirectToAction("ProductDetails");
        }


    }

    
}