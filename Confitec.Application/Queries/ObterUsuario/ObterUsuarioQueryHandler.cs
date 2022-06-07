using Confitec.Application.ViewModels;
using Confitec.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confitec.Application.Queries.ObterUsuario
{
    public class ObterUsuarioQueryHandler : IRequestHandler<ObterUsuarioQuery, UsuarioViewModel>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public ObterUsuarioQueryHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<UsuarioViewModel> Handle(ObterUsuarioQuery request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.ObterPorId(request.Id);

            if (usuario == null)
            {
                return null;
            }

            return new UsuarioViewModel(usuario.Id, usuario.Nome, usuario.Sobrenome, usuario.Email, usuario.DataNascimento, usuario.HistoricoEscolar.Formato, usuario.HistoricoEscolar.Nome, usuario.EscolaridadeId);
        }
    }
}
