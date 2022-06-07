using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confitec.Core.Entities
{
    public class Escolaridade : BaseEntity
    {
        public string Descricao { get; set; }
        public virtual List<Usuario> Usuarios { get; private set; }
    }
}
