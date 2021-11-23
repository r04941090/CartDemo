using CartDemo.Services.Interface;
using CartDemo.ViewModels.APIBase;
using CartDemo.ViewModels.Order;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartDemo.Controllers.WebAPI
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderWebApiController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderWebApiController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpPost]
        public ApiResponse CheckOut(CheckOutViewModel CheckOutViewModel)
        {
            try
            {
                _orderService.CheckOut(CheckOutViewModel);
                return new ApiResponse(APIStatus.Success, string.Empty, true);
            }
            catch(Exception ex)
            {
                return new ApiResponse(APIStatus.Fail, ex.Message, false);
            }
        }
        [HttpGet]
        public ApiResponse GetOrderList(int UserId)
        {
            try
            {
                var result = _orderService.GetOrderList(UserId);
                return new ApiResponse(APIStatus.Success, string.Empty, result);
            }
            catch(Exception ex)
            {
                return new ApiResponse(APIStatus.Fail, ex.Message, false);
            }
        }
        [HttpGet]
        public ApiResponse GetOrderDetail(int OrderId)
        {
            try
            {
                var result = _orderService.GetOrderDetail(OrderId);
                return new ApiResponse(APIStatus.Success, string.Empty, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse(APIStatus.Fail, ex.Message, false);
            }
        }
    }
}
