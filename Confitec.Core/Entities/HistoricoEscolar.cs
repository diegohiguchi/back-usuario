using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confitec.Core.Entities
{
    public class HistoricoEscolar : BaseEntity
    {
        public HistoricoEscolar(string formato, string nome)
        {
            Formato = formato;
            Nome = nome;
        }

        public string Formato { get; private set; }
        public string Nome { get; private set; }
        public Usuario Usuario { get; private set; }

        public void AlterarHistoricoEscolar(string formato, string nome)
        {
            Formato = formato;
            Nome = nome;
        }
    }
}
