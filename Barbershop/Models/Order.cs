using System;
using System.Collections.Generic;

#nullable disable

namespace Barbershop.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public int? ClientId { get; set; }
        public DateTime? Date { get; set; }

        public virtual Client Client { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
