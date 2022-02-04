using System;
using System.Collections.Generic;
using HealthInsurance.EntityLayer.Concrete.Bases;

#nullable disable

namespace HealthInsurance.EntityLayer.Concrete.Models
{
    public partial class IndividualCustomer : Entity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string IdentityNumber { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
