using CartDemo.Models.DataModels;
using CartDemo.Repositories.Interface;
using CartDemo.Services.Interface;
using CartDemo.ViewModels.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartDemo.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository _repository;
        public OrderService(IRepository repository)
        {
            _repository = repository;
        }
        public void CheckOut(CheckOutViewModel CheckOutViewModel)
        {
            // 建立訂單 -> 建立訂單詳情 -> 刪除購物車
            using(var tran = _repository._ctx.Database.BeginTransaction())
            {
                try
                {
                    var selectShoppingCarts = _repository.GetAll<ShoppingCart>().Where(x => x.UserId == CheckOutViewModel.UserId).ToList();
                    var selectProducts = _repository.GetAll<Product>().Where(x => selectShoppingCarts.Select(y => y.ProductId).Contains(x.ProductId)).ToList();
                    // 建立訂單
                    var order = new Order()
                    {
                        UserId = CheckOutViewModel.UserId,
                        OrderDate = DateTime.UtcNow,
                        TotalPrice = CheckOutViewModel.TotalPrice
                    };
                    _repository.Create(order);
                    _repository.SaveChange();

                    // 建立訂單詳情
                    foreach (var ShoppingCart in selectShoppingCarts)
                    {
                        var selectProduct = selectProducts.First(x => x.ProductId == ShoppingCart.ProductId);
                        var OrderDetail = new OrderDetail()
                        {
                            OrderId = order.OrderId,
                            ProductName = selectProduct.ProductName,
                            Number = ShoppingCart.Number,
                            UnitPrice = selectProduct.UnitPrice
                        };
                        _repository.Create(OrderDetail);
                    }
                    _repository.SaveChange();

                    // 刪除購物車
                    foreach (var ShoppingCart in selectShoppingCarts)
                    {
                        _repository.Delete(ShoppingCart);
                    }
                    _repository.SaveChange();
                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                }
            }
        }
        public OrderList GetOrderList(int UserId)
        {
            var selectOrders = _repository.GetAll<Order>().Where(x => x.UserId == UserId).Select(x => new OrderElement()
            {
                OrderId = x.OrderId,
                OrderDate = x.OrderDate,
                TotalPrice = x.TotalPrice
            }).ToList();
            OrderList orderList = new OrderList()
            {
                Orders = selectOrders
            };
            return orderList;
        }

        public OrderDetailViewModel GetOrderDetail(int OrderId)
        {
            var selectOrderDetails = _repository.GetAll<OrderDetail>().Where(x => x.OrderId == OrderId)
                                                                      .Select(x => new OrderDetailModel() 
                                                                      {
                                                                          ProductName = x.ProductName, 
                                                                          Number = x.Number, 
                                                                          UnitPrice = x.UnitPrice 
                                                                      }).ToList();
            OrderDetailViewModel orderDetailViewModel = new OrderDetailViewModel()
            {
                OrderDetailModels = selectOrderDetails
            };
            return orderDetailViewModel;
        }

        
    }
}
