using Confitec.Core.Entities;
using Confitec.Core.Repositories;
using MediatR;

namespace Confitec.Application.Queries.ObterTodasEscolaridade
{
    public class ObterTodasEscolidadeQueryHandler : IRequestHandler<ObterTodasEscolaridadeQuery, List<Escolaridade>>
    {
        private readonly IEscolaridadeRepository _escolaridadeRepository;

        public ObterTodasEscolidadeQueryHandler(IEscolaridadeRepository escolaridadeRepository)
        {
            _escolaridadeRepository = escolaridadeRepository;
        }

        public async Task<List<Escolaridade>> Handle(ObterTodasEscolaridadeQuery request, CancellationToken cancellationToken)
        {
           return await _escolaridadeRepository.ObterTodos();
        }
    }
}
