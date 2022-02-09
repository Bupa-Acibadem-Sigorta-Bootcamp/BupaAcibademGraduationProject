using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthInsurance.EntityLayer.Concrete.Bases;

namespace HealthInsurance.EntityLayer.Concrete.Dtos
{
    public class DtoGeneralManagerScreen : Dto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Title { get; set; }
        public int? Price { get; set; }

        public string InstallmentType { get; set; }
      
    }
}
