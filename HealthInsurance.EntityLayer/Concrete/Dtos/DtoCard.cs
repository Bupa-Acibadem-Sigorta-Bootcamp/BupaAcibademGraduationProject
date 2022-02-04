using System;
using System.Collections.Generic;
using HealthInsurance.EntityLayer.Concrete.Bases;

#nullable disable

namespace HealthInsurance.EntityLayer.Concrete.Dtos
{
    public partial class DtoCard : Dto
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public string CardHolderFirstNameLastName { get; set; }
        public string CreditCardNumber { get; set; }
        public string ValidThru { get; set; }
        public string CardValidationValue { get; set; }
    }
}
