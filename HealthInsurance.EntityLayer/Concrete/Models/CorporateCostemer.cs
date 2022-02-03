using System;
using System.Collections.Generic;

#nullable disable

namespace HealthInsurance.EntityLayer.Concrete.Models
{
    public partial class CorporateCostemer
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public string CompanyName { get; set; }
        public string TaxNumber { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
