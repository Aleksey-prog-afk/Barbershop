using System;
using System.Collections.Generic;

#nullable disable

namespace Barbershop.Models
{
    public partial class Master
    {
        public Master()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int? SheduleId { get; set; }

        public virtual Schedule Shedule { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
