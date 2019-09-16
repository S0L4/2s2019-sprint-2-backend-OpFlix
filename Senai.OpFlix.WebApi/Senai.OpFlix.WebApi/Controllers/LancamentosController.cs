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
    public class LancamentosController : ControllerBase
    {
        private ILancamentoRepository LancamentoRepository { get; set; }

        public LancamentosController()
        {
            LancamentoRepository = new LancamentoRepository();
        }

        [Authorize]
        [HttpGet]
        public IActionResult ListarLancamentos()
        {
            return Ok(LancamentoRepository.Listar());
        }

        [Authorize(Roles = "Administrador")]
        [HttpGet("{id}")]
        public IActionResult BuscarLancamentoPorId(int id)
        {
            Lancamentos Lancamento = LancamentoRepository.BuscarPorId(id);

            if (Lancamento == null)
            {
                return NotFound();
            }
            return Ok(Lancamento);
        }

        [Authorize(Roles = "Administrador")]
        [HttpGet("{plataforma}")]
        public IActionResult BuscarLancamentoPorPlataforma(string nome)
        {
            Lancamentos Lancamento = LancamentoRepository.BuscarPorPlataforma(nome);

            if (Lancamento == null)
            {
                return NotFound();
            }
            return Ok(Lancamento);
        }

        [Authorize(Roles = "Administrador")]
        [HttpGet("{plataforma}")]
        public IActionResult BuscarLancamentoPorData(DateTime data)
        {
            Lancamentos Lancamento = LancamentoRepository.BuscarPorDataLancamento(data);

            if (Lancamento == null)
            {
                return NotFound();
            }
            return Ok(Lancamento);
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult CadastrarLancamento(Lancamentos lancamento)
        {
            try
            {
                LancamentoRepository.Cadastrar(lancamento);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [Authorize(Roles = "Administrador")]
        [HttpPut]
        public IActionResult AtualizarLancamento(Lancamentos lancamento)
        {
            try
            {
                Lancamentos LancamentoEncontrado = LancamentoRepository.BuscarPorId(lancamento.IdLancamento);

                if (LancamentoEncontrado == null)
                {
                    return NotFound();
                }
                LancamentoRepository.Atualizar(lancamento);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [Authorize(Roles = "Administrador")]
        [HttpDelete("{id}")]
        public IActionResult DeletarLancamento(int id)
        {
            LancamentoRepository.Deletar(id);
            return Ok();
        }
    }
}