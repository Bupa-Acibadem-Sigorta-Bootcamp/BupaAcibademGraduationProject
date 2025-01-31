﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthInsurance.EntityLayer.Concrete.Bases;
using HealthInsurance.EntityLayer.Concrete.Models;
using HealthInsurance.InterfaceLayer.Abstract.IGenericService;

namespace HealthInsurance.WebApiLayer.Controllers.ControllerBases
{
    [Route("api/[controller]s")]
    [ApiController]
    public class BasesController<TInterface, T, TDto> : ControllerBase
        where TInterface : IGenericService<T, TDto>
        where T : Entity
        where TDto : Dto
    {
        private readonly TInterface _service;

        public BasesController(TInterface service)
        {
            _service = service;
        }

        [HttpPost("Add")]
        public IActionResult Add(TDto dto)
        {
            var result = _service.Add(dto);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("AddAsync")]
        public async Task<IActionResult> AddAsync(TDto dto)
        {
            var result = await _service.AddAsync(dto);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("DeleteById")]
        public IActionResult DeleteById(int id)
        {
            var result = _service.DeleteById(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("Find")]
        public IActionResult Find(int id)
        {
            var result = _service.Find(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _service.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //TODO : Tipin belli olduğu yerde kullanılabilir.
        [HttpGet("GetAllExpression")]
        public IActionResult GetAllAsycn()
        {
            var result = _service.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
