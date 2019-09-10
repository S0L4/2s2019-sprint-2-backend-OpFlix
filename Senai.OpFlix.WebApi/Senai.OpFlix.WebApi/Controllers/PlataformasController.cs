using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using Senai.OpFlix.WebApi.Repositories;

namespace Senai.OpFlix.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class PlataformasController : ControllerBase
    {
        private IPlataformaRepository PlataformaRepository { get; set; }

        public PlataformasController()
        {
            PlataformaRepository = new PlataformaRepository();
        }

        [Authorize]
        [HttpGet]
        public IActionResult ListarPlataformas()
        {
            return Ok(PlataformaRepository.Listar());
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult CadastrarPlataforma(Plataformas plataforma)
        {
            try
            {
                PlataformaRepository.Cadastrar(plataforma);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [Authorize(Roles = "Administrador")]
        [HttpPut]
        public IActionResult AtualizarPlataforma(Plataformas plataforma)
        {
            try
            {
                Plataformas PlataformaEncontrada = PlataformaRepository.BuscarPorId(plataforma.IdPlataforma);

                if (PlataformaEncontrada == null)
                {
                    return NotFound();
                }
                PlataformaRepository.Atualizar(plataforma);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(new { mensagem = ex.Message });
            }
        }
    }
}