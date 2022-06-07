using Confitec.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confitec.Core.Repositories
{
    public interface IEscolaridadeRepository
    {
        Task<List<Escolaridade>> ObterTodos();
        Task<Escolaridade> ObterPorId(int id);
        Task Salvar(Escolaridade escolaridade);
    }
}
