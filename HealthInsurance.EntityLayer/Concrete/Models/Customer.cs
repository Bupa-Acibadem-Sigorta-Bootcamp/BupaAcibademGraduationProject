using System;
using System.Collections.Generic;
using HealthInsurance.EntityLayer.Concrete.Bases;

#nullable disable

namespace HealthInsurance.EntityLayer.Concrete.Models
{
    public partial class Customer : Entity
    {
        public Customer()
        {
            Cards = new HashSet<Card>();
            CorporateCustomers = new HashSet<CorporateCustomer>();
            IndividualCustomers = new HashSet<IndividualCustomer>();
            Orders = new HashSet<Order>();
            Payments = new HashSet<Payment>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Card> Cards { get; set; }
        public virtual ICollection<CorporateCustomer> CorporateCustomers { get; set; }
        public virtual ICollection<IndividualCustomer> IndividualCustomers { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
