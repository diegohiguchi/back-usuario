using Confitec.Application.ViewModels;
using Confitec.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confitec.Application.Queries.ObterEscolaridade
{
    public class ObterEscolaridadeQueryHandler : IRequestHandler<ObterEscolaridadeQuery, EscolaridadeViewModel>
    {
        private readonly IEscolaridadeRepository _escolaridadeRepository;

        public ObterEscolaridadeQueryHandler(IEscolaridadeRepository escolaridadeRepository)
        {
            _escolaridadeRepository = escolaridadeRepository;
        }

        public async Task<EscolaridadeViewModel> Handle(ObterEscolaridadeQuery request, CancellationToken cancellationToken)
        {
            var escolaridade = await _escolaridadeRepository.ObterPorId(request.Id);

            if (escolaridade == null)
            {
                return null;
            }

            return new EscolaridadeViewModel(escolaridade.Id, escolaridade.Descricao);
        }
    }
}
