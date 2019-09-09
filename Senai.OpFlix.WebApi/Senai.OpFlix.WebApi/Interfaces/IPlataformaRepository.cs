using Senai.OpFlix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Interfaces
{
    interface IPlataformaRepository
    {
        List<Plataformas> Listar();
        Plataformas BuscarPorId(int id);
        void Cadastrar(Plataformas categoria);
        void Atualizar(Plataformas categoria);
    }
}
