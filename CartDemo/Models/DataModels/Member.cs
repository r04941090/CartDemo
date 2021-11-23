using System;
using System.Collections.Generic;

#nullable disable

namespace CartDemo.Models.DataModels
{
    public partial class Member
    {
        public Member()
        {
            ShoppingCarts = new HashSet<ShoppingCart>();
        }

        public int UserId { get; set; }
        public string Account { get; set; }

        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }
    }
}
