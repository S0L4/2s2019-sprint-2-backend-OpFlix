using Microsoft.EntityFrameworkCore;
using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class LancamentoRepository : ILancamentoRepository
    {
        OpFlixContext ctx = new OpFlixContext();

        public void Atualizar(Lancamentos lancamento)
        {
            Lancamentos LancamentoBuscado = ctx.Lancamentos.FirstOrDefault(x => x.IdLancamento == lancamento.IdLancamento);
            LancamentoBuscado.Titulo = lancamento.Titulo;
            LancamentoBuscado.Sinopse = lancamento.Sinopse;
            LancamentoBuscado.IdCategoriaNavigation = lancamento.IdCategoriaNavigation;
            LancamentoBuscado.IdClassificaoNavigation = lancamento.IdClassificaoNavigation;
            LancamentoBuscado.DuracaoMin = lancamento.DuracaoMin;
            LancamentoBuscado.IdTipoLancamentoNavigation = lancamento.IdTipoLancamentoNavigation;
            LancamentoBuscado.DataLancamento = lancamento.DataLancamento;
        }

        public Lancamentos BuscarPorId(int id)
        {
            Lancamentos lancamento = ctx.Lancamentos.FirstOrDefault(x => x.IdLancamento == id);
            return lancamento;
        }

        public void Cadastrar(Lancamentos lancamento)
        {
            ctx.Lancamentos.Add(lancamento);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Lancamentos lancamento = ctx.Lancamentos.Find(id);
            ctx.Lancamentos.Remove(lancamento);
            ctx.SaveChanges();
        }

        public List<Lancamentos> Listar()
        {
            return ctx.Lancamentos.Include(x => x.IdCategoriaNavigation).Include(x => x.IdClassificaoNavigation).Include(x => x.IdPlataformaNavigation).Include(x => x.IdTipoLancamentoNavigation).ToList();
        }
    }
}
