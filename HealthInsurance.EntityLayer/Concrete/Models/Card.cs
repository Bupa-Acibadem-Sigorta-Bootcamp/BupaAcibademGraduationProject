using System;
using System.Collections.Generic;
using HealthInsurance.EntityLayer.Concrete.Bases;

#nullable disable

namespace HealthInsurance.EntityLayer.Concrete.Models
{
    public partial class Card : Entity
    {
        public Card()
        {
            Payments = new HashSet<Payment>();
        }

        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public string CardHolderFirstNameLastName { get; set; }
        public string CreditCardNumber { get; set; }
        public string ValidThru { get; set; }
        public string CardValidationValue { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
