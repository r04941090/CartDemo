using System;
using System.Collections.Generic;

#nullable disable

namespace CartDemo.Models.DataModels
{
    public partial class Product
    {
        public Product()
        {
            ShoppingCarts = new HashSet<ShoppingCart>();
        }

        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public int Stock { get; set; }
        public string Unit { get; set; }
        public decimal UnitPrice { get; set; }
        public string Image { get; set; }

        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }
    }
}
