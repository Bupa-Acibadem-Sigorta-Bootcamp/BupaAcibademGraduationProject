using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthInsurance.BusinessLogicLayer.Concrete.BusinessLogicLayerBase;
using HealthInsurance.EntityLayer.Concrete.Dtos;
using HealthInsurance.EntityLayer.Concrete.Models;
using HealthInsurance.InterfaceLayer.Abstract.IModelService;

namespace HealthInsurance.BusinessLogicLayer.Concrete.BusinessLogicManagers
{
    public class CorporateCostemerManager : BusinessLogicBase<CorporateCostemer, DtoCorporateCostemer>, ICorporateCostemerService
    {
        public CorporateCostemerManager(IServiceProvider service) : base(service)
        {
        }
    }
}
