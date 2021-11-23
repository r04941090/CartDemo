using CartDemo.Models.DataModels;
using CartDemo.Repositories.Interface;
using CartDemo.Services.Interface;
using CartDemo.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartDemo.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository _repository;
        public ProductService(IRepository repository)
        {
            _repository = repository;
        }

        public ProductViewModel GetProductList()
        {
            ProductViewModel productViewModel = new ProductViewModel();
            var ProductModels = _repository.GetAll<Product>().Select(x => new ProductModel()
            {
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                Image = x.Image,
                Price = Convert.ToDecimal(x.UnitPrice)
            }).ToList();
            productViewModel.ProductModels = ProductModels;
            return productViewModel;
        }
    }
}
