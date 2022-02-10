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
    public class IndividualCustomerController : BasesController<IIndividualCustomerService, IndividualCustomer, DtoIndividualCustomer>
    {
        private readonly IIndividualCustomerService _individualCustomerService;
        public IndividualCustomerController(IIndividualCustomerService service, IIndividualCustomerService individualCustomerService) : base(service)
        {
            _individualCustomerService = individualCustomerService;
        }
        [HttpGet("GetAllDetailIndividualCustomer")]
        public IActionResult GetAllDetailIndividualCustomer()
        {
            var result = _individualCustomerService.GetAllDetailIndividualCustomer();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
