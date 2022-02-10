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
    [Route("api/[controller]s")]
    [ApiController]
    public class CorporateCustomerController : BasesController<ICorporateCustomerService, CorporateCustomer, DtoCorporateCustomer>
    {
        private readonly ICorporateCustomerService _corporateCustomerService;
        public CorporateCustomerController(ICorporateCustomerService service, ICorporateCustomerService corporateCustomerService) : base(service)
        {
            _corporateCustomerService = corporateCustomerService;
        }

        [HttpGet("GetAllDetailCorporateCustomer")]
        public IActionResult GetAllDetailCorporateCustomer()
        {
            var result = _corporateCustomerService.GetAllDetailCorporateCustomer();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
