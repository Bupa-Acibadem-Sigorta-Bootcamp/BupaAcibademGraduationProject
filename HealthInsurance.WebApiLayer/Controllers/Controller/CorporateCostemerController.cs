using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthInsurance.EntityLayer.Concrete.Dtos;
using HealthInsurance.EntityLayer.Concrete.Models;
using HealthInsurance.InterfaceLayer.Abstract.IModelService;
using HealthInsurance.WebApiLayer.Controllers.ControllerBases;

namespace HealthInsurance.WebApiLayer.Controllers.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorporateCostemerController :BasesController<ICorporateCostemerService, CorporateCostemer, DtoCorporateCostemer>
    {
        public CorporateCostemerController(ICorporateCostemerService service) : base(service)
        {
        }
    }
}
