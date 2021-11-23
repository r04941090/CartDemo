using CartDemo.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartDemo.Services.Interface
{
    public interface IProductService
    {
        public ProductViewModel GetProductList();
    }
}
