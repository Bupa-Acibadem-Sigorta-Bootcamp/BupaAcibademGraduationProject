using System;
using System.Collections.Generic;
using HealthInsurance.EntityLayer.Concrete.Bases;

#nullable disable

namespace HealthInsurance.EntityLayer.Concrete.Dtos
{
    public partial class DtoProduct : Dto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? Price { get; set; }
    }
}
