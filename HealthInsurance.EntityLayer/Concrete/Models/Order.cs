using System;
using System.Collections.Generic;
using HealthInsurance.EntityLayer.Concrete.Bases;

#nullable disable

namespace HealthInsurance.EntityLayer.Concrete.Models
{
    public partial class Order : Entity
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public int? ProductId { get; set; }
        public string OrderDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}
