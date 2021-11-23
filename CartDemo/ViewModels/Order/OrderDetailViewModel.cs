using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartDemo.ViewModels.Order
{
    public class OrderDetailViewModel
    {
        public List<OrderDetailModel> OrderDetailModels { get; set; }
    }
    public class OrderDetailModel
    {
        public string ProductName { get; set; }
        public int Number { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
