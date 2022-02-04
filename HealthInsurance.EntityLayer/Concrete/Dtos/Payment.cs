using System;
using System.Collections.Generic;
using HealthInsurance.EntityLayer.Concrete.Bases;

#nullable disable

namespace HealthInsurance.EntityLayer.Concrete.Dtos
{
    public partial class Payment : Dto
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public int? CardId { get; set; }
        public string PaymentDate { get; set; }
        public string PaymentType { get; set; }
        public string InstallmentType { get; set; }
    }
}
