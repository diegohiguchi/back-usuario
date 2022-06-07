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
    public class EscolaridadeRepository : IEscolaridadeRepository
    {
        private readonly ConfitecDbContext _dbContext;
        public EscolaridadeRepository(ConfitecDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Escolaridade>> ObterTodos()
        {
            return await _dbContext.Escolaridades.ToListAsync();
        }

        public async Task<Escolaridade> ObterPorId(int id)
        {
            return await _dbContext.Escolaridades
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task Salvar(Escolaridade escolaridade)
        {
            await _dbContext.Escolaridades.AddAsync(escolaridade);
            await _dbContext.SaveChangesAsync();
        }
    }
}
