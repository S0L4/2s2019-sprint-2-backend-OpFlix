using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class TipoLancamentoRepository : ITipoLancamentoRepository
    {
        OpFlixContext ctx = new OpFlixContext();

        public void Atualizar(TipoLancamento tipoLancamento)
        {
            TipoLancamento TipoBuscado = ctx.TipoLancamento.FirstOrDefault(x => x.IdTipoLancamento == tipoLancamento.IdTipoLancamento);
            TipoBuscado.Tipo = tipoLancamento.Tipo;
            ctx.TipoLancamento.Update(TipoBuscado);
            ctx.SaveChanges();
        }

        public TipoLancamento BuscarPorId(int id)
        {
            TipoLancamento tipoLancamento = ctx.TipoLancamento.FirstOrDefault(x => x.IdTipoLancamento == id);
            return tipoLancamento;
        }

        public void Cadastrar(TipoLancamento tipoLancamento)
        {
            ctx.TipoLancamento.Add(tipoLancamento);
            ctx.SaveChanges();
        }

        public List<TipoLancamento> Listar()
        {
            return ctx.TipoLancamento.ToList(); 
        }
    }
}
