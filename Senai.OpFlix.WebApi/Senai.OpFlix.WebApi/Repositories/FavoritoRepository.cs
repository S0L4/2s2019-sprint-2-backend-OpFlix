using Microsoft.EntityFrameworkCore;
using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class FavoritoRepository : IFavoritoRepository
    {
        OpFlixContext ctx = new OpFlixContext();

        public List<Favoritos> BuscarPorId(int id)
        {
            return ctx.Favoritos.Include(x => x.IdLancamentoNavigation).Where(x => x.IdUsuarioNavigation.IdUsuario == id).ToList();          
        }

        public void Cadastrar(Favoritos favorito)
        {
            ctx.Favoritos.Add(favorito);
            ctx.SaveChanges();
        }

        public List<Favoritos> Listar()
        {
            return ctx.Favoritos.Include(x => x.IdUsuarioNavigation).Include(x => x.IdLancamentoNavigation).ToList();
        }

        
    }
}
