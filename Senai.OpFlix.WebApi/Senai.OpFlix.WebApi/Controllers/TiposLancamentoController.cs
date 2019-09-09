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
    public class TiposLancamentoController : ControllerBase
    {
        private ITipoLancamentoRepository TipoLancamentoRepository { get; set; }

        public TiposLancamentoController()
        {
            TipoLancamentoRepository = new TipoLancamentoRepository();
        }

        [HttpGet]
        public IActionResult ListarTiposLanc()
        {
            return Ok(TipoLancamentoRepository.Listar());
        }

        [HttpPost]
        public IActionResult CadastrarTiposLanc(TipoLancamento tipoLancamento)
        {
            try
            {
                TipoLancamentoRepository.Cadastrar(tipoLancamento);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpPut]
        public IActionResult AtualizarTipoLanc(TipoLancamento tipoLancamento)
        {
            try
            {
                TipoLancamento TipoEncontrado = TipoLancamentoRepository.BuscarPorId(tipoLancamento.IdTipoLancamento);

                if (TipoEncontrado == null)
                {
                    return NotFound();
                }
                TipoLancamentoRepository.Atualizar(tipoLancamento);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(new { mensagem = ex.Message });
            }
        }
    }
}