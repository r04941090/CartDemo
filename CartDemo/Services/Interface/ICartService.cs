using CartDemo.ViewModels.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartDemo.Services.Interface
{
    public interface ICartService
    {
        void AddProductToCart(ShoppingCartElement ShoppingCartElement);
        ShoppingCartList GetShoppingCartList(int UserId);
        void DeleteShoppingCartElement(int ShoppingCarId);
        void UpdateShoppingCartList(UpdateShoppingCartList UpdateShoppingCartList);
    }
}
