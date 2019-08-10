using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreFitness.Models
{
    public class SQLShoppingCartRepository : IShoppingCartRepository
    {

        private readonly AppDbContext context;

        public SQLShoppingCartRepository(AppDbContext context)
        {
            this.context = context;
        }

        

        public IEnumerable<ShoppingCart> GetShoppingCart()
        {
            return context.ShoppingCart;
        }

        public ShoppingCart Delete(int id)
        {
            ShoppingCart shoppingCart = context.ShoppingCart.Find(id);
            if (shoppingCart != null)
            {
                context.ShoppingCart.Remove(shoppingCart);
                context.SaveChanges();
            }
            return shoppingCart;
        }
    }
}
