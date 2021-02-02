using System;
using System.Collections.Generic;

#nullable disable

namespace Barbershop.Models
{
    public partial class Schedule
    {
        public Schedule()
        {
            Masters = new HashSet<Master>();
        }

        public int Id { get; set; }
        public TimeSpan? WorkBegins { get; set; }
        public TimeSpan? WorkEnds { get; set; }

        public virtual ICollection<Master> Masters { get; set; }
    }
}
