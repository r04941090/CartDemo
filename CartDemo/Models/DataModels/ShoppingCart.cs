using System;
using System.Collections.Generic;

#nullable disable

namespace CartDemo.Models.DataModels
{
    public partial class ShoppingCart
    {
        public int ShoppingCartId { get; set; }
        public int UserId { get; set; }
        public string ProductId { get; set; }
        public int Number { get; set; }

        public virtual Product Product { get; set; }
        public virtual Member User { get; set; }
    }
}
