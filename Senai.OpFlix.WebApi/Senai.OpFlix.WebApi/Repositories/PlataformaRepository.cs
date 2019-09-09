using Microsoft.EntityFrameworkCore;
using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class PlataformaRepository : IPlataformaRepository
    {
        OpFlixContext ctx = new OpFlixContext();

        public void Atualizar(Plataformas plataforma)
        {
            Plataformas PlataformaBuscada = ctx.Plataformas.FirstOrDefault(x => x.IdPlataforma == plataforma.IdPlataforma);
            PlataformaBuscada.Nome = plataforma.Nome;
            ctx.Plataformas.Update(PlataformaBuscada);
            ctx.SaveChanges();
        }

        public Plataformas BuscarPorId(int id)
        {
            Plataformas plataforma = ctx.Plataformas.FirstOrDefault(x => x.IdPlataforma == id);
            return plataforma;
        }

        public void Cadastrar(Plataformas plataforma)
        {
            ctx.Plataformas.Add(plataforma);
            ctx.SaveChanges();
        }

        public List<Plataformas> Listar()
        {
            return ctx.Plataformas.ToList();
        }
    }
}
