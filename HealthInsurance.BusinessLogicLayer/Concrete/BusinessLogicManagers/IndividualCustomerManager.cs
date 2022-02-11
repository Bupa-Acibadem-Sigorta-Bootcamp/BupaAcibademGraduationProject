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
    public class IndividualCustomerManager : BusinessLogicBase<IndividualCustomer, DtoIndividualCustomer>,
        IIndividualCustomerService
    {
        public IndividualCustomerManager(IServiceProvider service) : base(service)
        {
        }

        public IDataResult<List<DtoDetailIndividualCustomer>> GetAllDetailIndividualCustomer()
        {
            try
            {
                var result = repository.GetAll();
                return new SuccessDataResult<List<DtoDetailIndividualCustomer>>(
                    ObjectMapper.Mapper.Map<List<IndividualCustomer>, List<DtoDetailIndividualCustomer>>(result),
                    Messages.IndividualCustomerInformationListed);
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<DtoDetailIndividualCustomer>>(null,
                    Messages.IndividualCustomerInformationNotListed);
            }
        }

        public IDataResult<DtoDetailIndividualCustomer> AddDetailIndividualCustomer(DtoDetailIndividualCustomer dtoDetailIndividualCustomer,
            bool saveChanges = true)
        {
            try
            {
                var resolvedResult = " ";
                var TResult = repository.Add(ObjectMapper.Mapper.Map<IndividualCustomer>(dtoDetailIndividualCustomer));
                resolvedResult = string.Join(',', TResult.GetType().GetProperties()
                    .Select(x => $"-{x.Name}: {x.GetValue(TResult) ?? ""}-"));
                if (saveChanges)
                {
                    Save();
                }

                return new SuccessDataResult<DtoDetailIndividualCustomer>(ObjectMapper.Mapper.Map<IndividualCustomer, DtoDetailIndividualCustomer>(TResult), Messages.IndividualCustomerAdded);
            }
            catch (Exception)
            {
                return new ErrorDataResult<DtoDetailIndividualCustomer>(Messages.IndividualCustomerNotAdded);
            }
        }
    }
}
