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
    public class CategoriasController : ControllerBase
    {
        private ICategoriaRepository CategoriaRepository { get; set; }

        public CategoriasController()
        {
            CategoriaRepository = new CategoriaRepository();
        }

        [Authorize]
        [HttpGet]
        public IActionResult ListarCategorias()
        {
            return Ok(CategoriaRepository.Listar());
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult CadastrarCategoria(Categorias categoria)
        {
            try
            {
                CategoriaRepository.Cadastrar(categoria);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [Authorize(Roles = "Administrador")]
        [HttpPut]
        public IActionResult AtualizarCategoria(Categorias categoria)
        {
            try
            {
                Categorias CategoriaEncontrada = CategoriaRepository.BuscarPorId(categoria.IdCategoria);

                if (CategoriaEncontrada == null)
                {
                    return NotFound();
                }
                CategoriaRepository.Atualizar(categoria);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(new { mensagem = ex.Message });
            }
        }
    }
}