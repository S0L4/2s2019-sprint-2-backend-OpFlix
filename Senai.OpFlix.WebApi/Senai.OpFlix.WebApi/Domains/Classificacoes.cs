using System;
using System.Collections.Generic;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class Classificacoes
    {
        public Classificacoes()
        {
            Lancamentos = new HashSet<Lancamentos>();
        }

        public int IdClassificacao { get; set; }
        public string Idade { get; set; }

        public ICollection<Lancamentos> Lancamentos { get; set; }
    }
}
