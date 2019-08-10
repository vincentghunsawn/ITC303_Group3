using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreFitness.Models
{
    public interface IShoppingCartRepository
    {


        IEnumerable<ShoppingCart> GetShoppingCart();

        ShoppingCart Delete(int id);
    }
}
