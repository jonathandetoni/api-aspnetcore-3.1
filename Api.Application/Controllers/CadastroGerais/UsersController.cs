using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Dtos.CadastrosGerais;
using Api.Domain.Entities.CadastrosGerais;
using Api.Domain.Interfaces.Service.Autenticacao;
using Api.Domain.Interfaces.Service.CadastrosGerais.User;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers.CadastrosGerais
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _service;
        private ILoginService _loginService;

        public UsersController(IUserService service,
                               ILoginService loginService)
        {
            _service = service;
            _loginService = loginService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _service.GetAll());
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}", Name = "GetWithId")]
        public async Task<ActionResult> Get(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _service.Get(id));
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserDto user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                if (string.IsNullOrWhiteSpace(user.Senha))
                    return null;

                byte[] passwordHash, passwordSalt;
                _loginService.CreatePasswordHash(user.Senha, out passwordHash, out passwordSalt);

                UserEntity userEntity = new UserEntity();

                userEntity.Email = user.Email;
                userEntity.SenhaHash = passwordHash;
                userEntity.SenhaSalt = passwordSalt;

                var result = await _service.Post(userEntity);

                if (result != null)
                {
                    return Created(new Uri(Url.Link("GetWithId", new { id = result.Id })), result);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UserEntity user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.Put(user);

                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _service.Delete(id));
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
