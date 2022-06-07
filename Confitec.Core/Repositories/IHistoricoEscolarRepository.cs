using Confitec.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confitec.Core.Repositories
{
    public interface IHistoricoEscolarRepository
    {
        Task<List<HistoricoEscolar>> ObterTodos();
        Task<HistoricoEscolar> ObterPorId(int id);
        Task Salvar(HistoricoEscolar historicoEscolar);
        Task Deletar(HistoricoEscolar historicoEscolar);
    }
}
