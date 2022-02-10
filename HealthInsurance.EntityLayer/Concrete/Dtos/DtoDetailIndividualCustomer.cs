using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthInsurance.EntityLayer.Concrete.Bases;

namespace HealthInsurance.EntityLayer.Concrete.Dtos
{
    public class DtoDetailIndividualCustomer : Dto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string IdentityNumber { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
    }
}
