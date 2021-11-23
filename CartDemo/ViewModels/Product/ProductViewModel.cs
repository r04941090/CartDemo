using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartDemo.ViewModels.Product
{
    public class ProductViewModel
    {
        public List<ProductModel> ProductModels { get; set; }
    }
    public class ProductModel
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
    }
}
