using System;
using System.Collections.Generic;

#nullable disable

namespace Barbershop.Models
{
    public partial class Service
    {
        public Service()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public decimal? Price { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public override string ToString()
        {
            return Title;
        }
    }
}
