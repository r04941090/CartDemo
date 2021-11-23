using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartDemo.ViewModels.Cart
{
    public class ShoppingCartElement
    {
        public int Number { get; set; }
        public string ProductId { get; set; }
        public int UserId { get; set; }
    }
}
