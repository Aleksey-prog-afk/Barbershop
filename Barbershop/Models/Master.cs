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
        public TimeSpan WorkBegins { get; set; }
        public TimeSpan WorkEnds { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public override string ToString()
        {
            return Name + " " + this.WorkBegins + " " + this.WorkEnds;
        }
    }
}
