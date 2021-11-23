using CartDemo.ViewModels.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartDemo.Services.Interface
{
    public interface IOrderService
    {
        void CheckOut(CheckOutViewModel CheckOutViewModel);
        OrderList GetOrderList(int UserId);
        OrderDetailViewModel GetOrderDetail(int OrderId);
    }
}
