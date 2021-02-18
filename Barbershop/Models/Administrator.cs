using System;
using System.Collections.Generic;

#nullable disable

namespace Barbershop.Models
{
    public partial class Administrator
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
    }
}
