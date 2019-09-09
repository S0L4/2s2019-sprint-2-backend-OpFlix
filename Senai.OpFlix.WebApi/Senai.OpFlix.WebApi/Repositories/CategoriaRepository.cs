using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        OpFlixContext ctx = new OpFlixContext();
       
        public void Atualizar(Categorias categoria)
        {
            Categorias CategoriaBuscada = ctx.Categorias.FirstOrDefault(x => x.IdCategoria == categoria.IdCategoria);
            CategoriaBuscada.Nome = categoria.Nome;
            ctx.Update(CategoriaBuscada);
            ctx.SaveChanges();
        }

        public void Cadastrar(Categorias categoria)
        {
            ctx.Categorias.Add(categoria);
            ctx.SaveChanges();
        }

        public Categorias BuscarPorId(int id)
        {
            Categorias categoria = ctx.Categorias.FirstOrDefault(x => x.IdCategoria == id);
            return categoria;
        }

        public List<Categorias> Listar()
        {
            return ctx.Categorias.ToList();
        }
    }
}
