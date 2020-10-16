﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TvPlus.Application.AppTv.Input;
using TvPlus.Application.AppTv.Interfaces;

namespace TvPlus.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioAppService _usuarioAppService;


        public UsuarioController(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }


        [HttpPost]
        [ProducesResponseType(typeof(string), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]

        public IActionResult Post([FromBody] UsuarioInput input)
        {
            try
            {
                var item = _usuarioAppService.Insert(input);
                return Created("", item);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro => {ex.Message}");
            }
        }


        [HttpGet] // api/hero
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]

        public IActionResult Get()
        {
            return Ok(_usuarioAppService.Get());
        }


        [HttpGet]// api/hero/id
        [Route("{id}")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]

        public IActionResult Get([FromRoute] int id)
        {
            return Ok(_usuarioAppService.GetById(id));
        }

    }
}
