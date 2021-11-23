using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartDemo.ViewModels.Cart
{
    public class ShoppingCartList
    {
        public List<ShoppingCartModel> shoppingCartModels { get; set; }
    }
    public class ShoppingCartModel
    {
        public string ProductName { get; set; }
        public string Image { get; set; }
        public int ShoppingCartId { get; set; }
        public int Number { get; set; }
        public decimal Price { get; set; }
    }
}
