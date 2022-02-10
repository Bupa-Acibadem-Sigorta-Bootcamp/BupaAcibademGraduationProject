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
    public class OrderManager : BusinessLogicBase<Order, DtoOrder>, IOrderService
    {
        public OrderManager(IServiceProvider service) : base(service)
        {
        }

        public IDataResult<List<DtoGeneralManagerScreen>> GetManagerScreens()
        {
            
            try
            {
                var result = repository.GetAll();
                return new SuccessDataResult<List<DtoGeneralManagerScreen>>(
                    ObjectMapper.Mapper.Map<List<Order>, List<DtoGeneralManagerScreen>>(result),Messages.OrdersListed);
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<DtoGeneralManagerScreen>>(null, Messages.OrdersNotListed);
            }
        }
    }
}
