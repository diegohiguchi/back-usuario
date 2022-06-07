using Confitec.Core.Entities;
using Confitec.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Confitec.Infrastructure.Persistence.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ConfitecDbContext _dbContext;
        public UsuarioRepository(ConfitecDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Usuario>> ObterTodos()
        {
            return await _dbContext.Usuarios
                .Include(p => p.Escolaridade)
                .Include(p => p.HistoricoEscolar).ToListAsync();
        }

        public async Task<Usuario> ObterPorId(int id)
        {
            return await _dbContext.Usuarios
                .Include(p => p.Escolaridade)
                .Include(p => p.HistoricoEscolar)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task Salvar(Usuario usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Deletar(Usuario usuario)
        {
            _dbContext.Usuarios.Remove(usuario);
            await _dbContext.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
