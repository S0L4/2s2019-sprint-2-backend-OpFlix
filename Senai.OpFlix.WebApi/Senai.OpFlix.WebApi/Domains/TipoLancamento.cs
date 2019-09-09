using System;
using System.Collections.Generic;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class TipoLancamento
    {
        public TipoLancamento()
        {
            Lancamentos = new HashSet<Lancamentos>();
        }

        public int IdTipoLancamento { get; set; }
        public string Tipo { get; set; }

        public ICollection<Lancamentos> Lancamentos { get; set; }
    }
}
