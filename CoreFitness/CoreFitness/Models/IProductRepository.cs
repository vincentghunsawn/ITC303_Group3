using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreFitness.Models
{
    public interface IProductRepository
    {

        Product GetProduct(int id);
        IEnumerable<Product> GetProducts();
        Product Add(Product product);
        Product Update(Product productChanges);
        Product Delete(int id);
        ShoppingCart AddToCart(ShoppingCart shoppingCart);
    }
}
