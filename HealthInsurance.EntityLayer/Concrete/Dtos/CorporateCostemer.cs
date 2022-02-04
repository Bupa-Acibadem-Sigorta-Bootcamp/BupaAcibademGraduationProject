using System;
using System.Collections.Generic;
using HealthInsurance.EntityLayer.Concrete.Bases;

#nullable disable

namespace HealthInsurance.EntityLayer.Concrete.Dtos
{
    public partial class CorporateCostemer : Dto
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public string CompanyName { get; set; }
        public string TaxNumber { get; set; }
    }
}
