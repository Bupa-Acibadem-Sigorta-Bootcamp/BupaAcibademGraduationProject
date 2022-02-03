using System;
using System.Collections.Generic;

#nullable disable

namespace HealthInsurance.EntityLayer.Concrete.Models
{
    public partial class Product
    {
        public Product()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int? Price { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
