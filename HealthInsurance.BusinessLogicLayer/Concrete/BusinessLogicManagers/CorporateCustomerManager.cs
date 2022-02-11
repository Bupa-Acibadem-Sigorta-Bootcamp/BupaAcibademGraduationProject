using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthInsurance.BusinessLogicLayer.Concrete.BusinessLogicLayerBase;
using HealthInsurance.BusinessLogicLayer.Concrete.MapperConfiguration;
using HealthInsurance.BusinessLogicLayer.Concrete.ResultMessages;
using HealthInsurance.EntityLayer.Abstract.IResults;
using HealthInsurance.EntityLayer.Concrete.Dtos;
using HealthInsurance.EntityLayer.Concrete.Models;
using HealthInsurance.EntityLayer.Concrete.Results;
using HealthInsurance.InterfaceLayer.Abstract.IModelService;

namespace HealthInsurance.BusinessLogicLayer.Concrete.BusinessLogicManagers
{
    public class CorporateCustomerManager : BusinessLogicBase<CorporateCustomer, DtoCorporateCustomer>, ICorporateCustomerService
    {
        public CorporateCustomerManager(IServiceProvider service) : base(service)
        {
        }

        public IDataResult<List<DtoDetailCorporateCustomer>> GetAllDetailCorporateCustomer()
        {
            try
            {
                var result = repository.GetAll();
                return new SuccessDataResult<List<DtoDetailCorporateCustomer>>(
                    ObjectMapper.Mapper.Map<List<CorporateCustomer>, List<DtoDetailCorporateCustomer>>(result), Messages.CorporateCustomerInformationListed);
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<DtoDetailCorporateCustomer>>(null, Messages.CorporateCustomerInformationNotListed);
            }
        }

        public IDataResult<DtoDetailCorporateCustomer> AddDtoDetailCorporateCustomer(DtoDetailCorporateCustomer dtoDetailCorporateCustomer,
            bool saveChanges = true)
        {
            try
            {
                var resolvedResult = " ";
                var TResult = repository.Add(ObjectMapper.Mapper.Map<CorporateCustomer>(dtoDetailCorporateCustomer));
                resolvedResult = string.Join(',', TResult.GetType().GetProperties()
                    .Select(x => $"-{x.Name}: {x.GetValue(TResult) ?? ""}-"));
                if (saveChanges)
                {
                    Save();
                }

                return new SuccessDataResult<DtoDetailCorporateCustomer>(ObjectMapper.Mapper.Map<CorporateCustomer, DtoDetailCorporateCustomer>(TResult), Messages.CorporateCustomerAdded);
            }
            catch (Exception)
            {
                return new ErrorDataResult<DtoDetailCorporateCustomer>(Messages.CorporateCustomerNotAdded);
            }
        }
    }
}
