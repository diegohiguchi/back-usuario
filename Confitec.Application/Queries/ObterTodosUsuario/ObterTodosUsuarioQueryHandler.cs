using Confitec.Core.Entities;
using Confitec.Core.Repositories;
using MediatR;

namespace Confitec.Application.Queries.ObterTodosUsuario
{
    public class ObterTodosUsuarioQueryHandler : IRequestHandler<ObterTodosUsuarioQuery, List<Usuario>>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public ObterTodosUsuarioQueryHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<List<Usuario>> Handle(ObterTodosUsuarioQuery request, CancellationToken cancellationToken)
        {
           return await _usuarioRepository.ObterTodos();
        }
    }
}
