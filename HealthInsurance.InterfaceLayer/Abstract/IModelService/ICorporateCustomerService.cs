﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthInsurance.EntityLayer.Abstract.IResults;
using HealthInsurance.EntityLayer.Concrete.Dtos;
using HealthInsurance.EntityLayer.Concrete.Models;
using HealthInsurance.InterfaceLayer.Abstract.IGenericService;

namespace HealthInsurance.InterfaceLayer.Abstract.IModelService
{
    public interface ICorporateCustomerService : IGenericService<CorporateCustomer, DtoCorporateCustomer>
    {
        IDataResult<List<DtoDetailCorporateCustomer>> GetAllDetailCorporateCustomer();
        IDataResult<DtoDetailCorporateCustomer> AddDtoDetailCorporateCustomer(DtoDetailCorporateCustomer dtoDetailCorporateCustomer, bool saveChanges = true);
    }
}
