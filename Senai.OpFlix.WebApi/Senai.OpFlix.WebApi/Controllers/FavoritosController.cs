using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class FavoritosController : ControllerBase
    {
        private IFavoritoRepository FavoritoRepository { get; set; }

        public FavoritosController()
        {
            FavoritoRepository = new FavoritoRepository();
        }

        [HttpGet]
        public IActionResult ListarFavoritos()
        {
            return Ok(FavoritoRepository.Listar());
        }

        [HttpPost]
        public IActionResult CadastrarFavorito(Favoritos favorito)
        {
            try
            {
                FavoritoRepository.Cadastrar(favorito);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarFavoritoPorUsuario(int id)
        {
            List<Favoritos> Favorito = FavoritoRepository.BuscarPorId(id);

            if (Favorito == null)
            {
                return NotFound();
            }
            return Ok(Favorito);
        }
    }
}