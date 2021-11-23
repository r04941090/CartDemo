using CartDemo.Models.DataModels;
using CartDemo.Repositories.Interface;
using CartDemo.Services.Interface;
using CartDemo.ViewModels.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartDemo.Services
{
    public class CartService : ICartService
    {
        private readonly IRepository _repository;
        public CartService(IRepository repository)
        {
            _repository = repository;
        }
        public void AddProductToCart(ShoppingCartElement ShoppingCartElement)
        {
            // 判斷是否此人的購物車已存在此商品
            var selectProduct= _repository.GetAll<ShoppingCart>().FirstOrDefault(x => x.ProductId == ShoppingCartElement.ProductId);
            if (selectProduct == null)
            {
                ShoppingCart shoppingCart = new ShoppingCart()
                {
                    UserId = ShoppingCartElement.UserId,
                    ProductId = ShoppingCartElement.ProductId,
                    Number = ShoppingCartElement.Number,
                };
                _repository.Create<ShoppingCart>(shoppingCart);
                _repository.SaveChange();
            }
            else
            {
                selectProduct.Number = ShoppingCartElement.Number;
                _repository.Update<ShoppingCart>(selectProduct);
                _repository.SaveChange();
            }
        }
        public ShoppingCartList GetShoppingCartList(int UserId)
        {
            
            var ShoppingCartList = _repository.GetAll<ShoppingCart>().Where(x => x.UserId == UserId).ToList();
            var selectProducts = _repository.GetAll<Product>().Where(x => ShoppingCartList.Select(y => y.ProductId).Contains(x.ProductId));
            ShoppingCartList shoppingCarts = new ShoppingCartList()
            {
                shoppingCartModels = new List<ShoppingCartModel>()
            };
            foreach (var item in ShoppingCartList)
            {
                var selectProduct = selectProducts.FirstOrDefault(x => x.ProductId == item.ProductId);
                ShoppingCartModel shoppingCartModel = new ShoppingCartModel()
                {
                    ShoppingCartId = item.ShoppingCartId,
                    ProductName = selectProduct.ProductName,
                    Price = selectProduct.UnitPrice,
                    Image = selectProduct.Image,
                    Number = item.Number
                };
                shoppingCarts.shoppingCartModels.Add(shoppingCartModel);
            }
            return shoppingCarts;
        }
        public void DeleteShoppingCartElement(int ShoppingCartId)
        {
            var selectShoppingCart = _repository.GetAll<ShoppingCart>().FirstOrDefault(x => x.ShoppingCartId == ShoppingCartId);
            _repository.Delete(selectShoppingCart);
            _repository.SaveChange();
        }
        public void UpdateShoppingCartList(UpdateShoppingCartList UpdateShoppingCartList)
        {
            var selectShoppingCartList = _repository.GetAll<ShoppingCart>().Where(x => UpdateShoppingCartList.SelectShoppingCarts.Select(y => y.ShoppingCartId).Contains(x.ShoppingCartId)).ToList();
            foreach (var item in selectShoppingCartList)
            {
                item.Number = UpdateShoppingCartList.SelectShoppingCarts.FirstOrDefault(x => x.ShoppingCartId == item.ShoppingCartId).Number;
                _repository.Update(item);
            }
            _repository.SaveChange();
        }
    }
}
