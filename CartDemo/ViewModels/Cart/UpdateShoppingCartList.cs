using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartDemo.ViewModels.Cart
{
    public class UpdateShoppingCartList
    {
        public List<SelectShoppingCart> SelectShoppingCarts { get; set; }
    }
    public class SelectShoppingCart
    {
        public int ShoppingCartId { get; set; }
        public int Number { get; set; }
    }
}
