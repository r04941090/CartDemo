using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartDemo.ViewModels.Order
{
    public class OrderList
    {
        public List<OrderElement> Orders { get; set; }
    }
    public class OrderElement
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
