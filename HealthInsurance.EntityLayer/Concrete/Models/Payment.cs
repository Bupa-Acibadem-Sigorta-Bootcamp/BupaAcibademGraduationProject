using System;
using System.Collections.Generic;

#nullable disable

namespace HealthInsurance.EntityLayer.Concrete.Models
{
    public partial class Payment
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public int? CardId { get; set; }
        public string PaymentDate { get; set; }
        public string PaymentType { get; set; }
        public string InstallmentType { get; set; }

        public virtual Card Card { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
