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
    public class OrderController : BasesController<IOrderService, Order, DtoOrder>
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService service, IOrderService orderService) : base(service)
        {
            _orderService = orderService;
        }

        [HttpGet("GetAllManagerScreens")]
        public IActionResult GetManagerScreens()
        {
            var result = _orderService.GetManagerScreens();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
