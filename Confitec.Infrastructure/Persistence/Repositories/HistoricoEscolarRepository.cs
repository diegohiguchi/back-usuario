using Confitec.Core.Entities;
using Confitec.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confitec.Infrastructure.Persistence.Repositories
{
    public class HistoricoEscolarRepository : IHistoricoEscolarRepository
    {
        private readonly ConfitecDbContext _dbContext;
        public HistoricoEscolarRepository(ConfitecDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<HistoricoEscolar>> ObterTodos()
        {
            return await _dbContext.HistoricosEscolar.ToListAsync();
        }

        public async Task<HistoricoEscolar> ObterPorId(int id)
        {
            return await _dbContext.HistoricosEscolar
                .Include(p => p.Usuario)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task Salvar(HistoricoEscolar usuario)
        {
            await _dbContext.HistoricosEscolar.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Deletar(HistoricoEscolar historicoEscolar)
        {
            _dbContext.HistoricosEscolar.Remove(historicoEscolar);
            await _dbContext.SaveChangesAsync();
        }
    }
}
