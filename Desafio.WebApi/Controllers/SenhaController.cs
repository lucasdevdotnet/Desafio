using Desafio.Dominio.Interfaces.ServicesInterface;
using Desafio.WebApi.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SenhaController : ControllerBase
    {
        private readonly ISenhaService _senhaService;
        public SenhaController(ISenhaService senhaService)
        {
            _senhaService = senhaService;
        }

        /// <summary>
        /// Validar a senha 
        /// </summary>
        /// <param name="senha"></param>
        /// <returns>A senha validada com sucesso</returns>
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(typeof(SenhaDto), 200)]
        [ProducesResponseType(400)]
        public IActionResult ValidarSenha(string senha)
        {
            if (_senhaService.SenhaEhValida(senha))
                return Ok("Senha Alterada");

            return BadRequest("Senha invalida");
        }

    }
    
}
