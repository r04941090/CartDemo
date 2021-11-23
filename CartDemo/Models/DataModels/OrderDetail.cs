using System;
using System.Collections.Generic;

#nullable disable

namespace CartDemo.Models.DataModels
{
    public partial class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public string ProductName { get; set; }
        public int Number { get; set; }
        public decimal UnitPrice { get; set; }

        public virtual Order Order { get; set; }
    }
}
