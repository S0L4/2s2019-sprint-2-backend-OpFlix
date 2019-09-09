using Senai.OpFlix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Interfaces
{
    interface ILancamentoRepository
    {
        List<Lancamentos> Listar();
        Lancamentos BuscarPorId(int id);
        void Cadastrar(Lancamentos categoria);
        void Atualizar(Lancamentos categoria);
        void Deletar(int id);
    }
}
