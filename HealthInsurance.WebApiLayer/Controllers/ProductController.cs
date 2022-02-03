using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthInsurance.DataAccessLayer.Concrete.ActiveDataObject.Net.Ado.NetRepository;
using HealthInsurance.EntityLayer.Concrete.Models;

namespace HealthInsurance.WebApiLayer.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        readonly AdoNetProductRepository adoNetProductRepository = new AdoNetProductRepository();

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = adoNetProductRepository.GetAll();
            if (result is not null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(Product product)
        {
            adoNetProductRepository.Add(new Product
            {
                Title = product.Title,
                Price = Convert.ToInt32(product.Price)
            });
            return Ok("Ürün Eklendi");
        }
    }
}
