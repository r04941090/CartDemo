using CartDemo.Services.Interface;
using CartDemo.ViewModels.APIBase;
using CartDemo.ViewModels.Cart;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CartDemo.ViewModels.APIBase.ApiResponse;

namespace CartDemo.Controllers.WebAPI
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CartWebApiController : ControllerBase
    {
        private ICartService _cartService;
        public CartWebApiController(ICartService cartService)
        {
            _cartService = cartService;
        }
        [HttpPost]
        public ApiResponse AddProductToCart(ShoppingCartElement ShoppingCartElement)
        {
            try
            {
                _cartService.AddProductToCart(ShoppingCartElement);
                return new ApiResponse(APIStatus.Success, string.Empty, true);
            }
            catch(Exception ex)
            {
                return new ApiResponse(APIStatus.Fail, ex.Message, false);
            }
        }
        [HttpGet]
        public ApiResponse GetShoppingCartList(int UserId)
        {
            try
            {
                var result = _cartService.GetShoppingCartList(UserId);
                return new ApiResponse(APIStatus.Success, string.Empty, result);
            }
            catch(Exception ex)
            {
                return new ApiResponse(APIStatus.Fail, ex.Message, false);
            }
        }
        [HttpDelete]
        public ApiResponse DeleteShoppingCartElement(int ShoppingCartId)
        {
            try
            {
                _cartService.DeleteShoppingCartElement(ShoppingCartId);
                return new ApiResponse(APIStatus.Success, string.Empty, true);
            }
            catch(Exception ex)
            {
                return new ApiResponse(APIStatus.Fail, ex.Message, false);
            }
        }
        [HttpPut]
        public ApiResponse UpdateShoppingCartList(UpdateShoppingCartList UpdateShoppingCartList)
        {
            try
            {
                _cartService.UpdateShoppingCartList(UpdateShoppingCartList);
                return new ApiResponse(APIStatus.Success, string.Empty, true);
            }
            catch (Exception ex)
            {
                return new ApiResponse(APIStatus.Fail, ex.Message, false);
            }
        }
    }
}
