using Confitec.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confitec.Core.Repositories
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> ObterTodos();
        Task<Usuario> ObterPorId(int id);
        Task Salvar(Usuario usuario);
        Task Deletar(Usuario usuario);
        Task SaveChangesAsync();
    }
}
