using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreFitness.Models
{
    public class SQLProductRepository : IProductRepository
    {

        private readonly AppDbContext context;

        
        public SQLProductRepository(AppDbContext context)
        {
            this.context = context;
        }
       
        public Product Add(Product product)
        {
            context.Add(product);
            context.SaveChanges();
            return product;
        }

        public Product Delete(int id)
        {
            Product product = context.Products.Find(id);
            if (product != null)
            {
                context.Products.Remove(product);
                context.SaveChanges();
            }
            return product;
        }

        public Product GetProduct(int id)
        {
            return context.Products.Find(id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return context.Products;
        }

        public Product Update(Product productChanges)
        {
            var product = context.Products.Attach(productChanges);

            product.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return productChanges;
        }

        public ShoppingCart AddToCart(ShoppingCart shoppingCart)
        {
            context.ShoppingCart.Add(shoppingCart);
            context.SaveChanges();
            return shoppingCart;
        }
    }
}
