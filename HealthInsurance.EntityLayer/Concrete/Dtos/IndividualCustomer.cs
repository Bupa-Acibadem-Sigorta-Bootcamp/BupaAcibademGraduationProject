using System;
using System.Collections.Generic;
using HealthInsurance.EntityLayer.Concrete.Bases;

#nullable disable

namespace HealthInsurance.EntityLayer.Concrete.Dtos
{
    public partial class IndividualCustomer : Dto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string IdentityNumber { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
    }
}
