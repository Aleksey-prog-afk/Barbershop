using System;
using System.Collections.Generic;

#nullable disable

namespace Barbershop.Models
{
    public partial class OrderDetail
    {
        public int OrderId { get; set; }
        public int ServiceId { get; set; }
        public int? MasterId { get; set; }
        public decimal? Cost { get; set; }

        public virtual Master Master { get; set; }
        public virtual Order Order { get; set; }
        public virtual Service Service { get; set; }
    }
}
