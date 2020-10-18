using System;
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
    public class UserController : ControllerBase
    {
        private readonly IUserAppService _usuarioAppService;


        public UserController(IUserAppService usuarioAppService)
        {
            try
            {
                _usuarioAppService = usuarioAppService;
            }
            catch(Exception e)
            {
                throw new Exception("Erro =>" + e);
            }
        }


        [HttpPost]
        [ProducesResponseType(typeof(string), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]

        public void /*IActionResult*/ Post([FromBody] UserInput input)
        {
            try
            {
               /* var item =*/ _usuarioAppService.Insert(input);
               /* return Created("", item);*/
            }
            catch (Exception ex)
            {
              /*  return*/ BadRequest($"Erro => {ex.Message}");
            }
        }


        [HttpGet] // api/hero
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult Get()
        {
            return Ok(_usuarioAppService.Get());
        }


        [HttpGet]// api/hero/id
        [Route("{id}")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            return   Ok(await _usuarioAppService.GetByIdAsync(id)
                    .ConfigureAwait(false));
        }

    }
}
