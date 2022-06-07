using Confitec.Core.Entities;
using Confitec.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confitec.Application.Commands.CriarUsuario
{
    public class CriarUsuarioCommandHandler : IRequestHandler<CriarUsuarioCommand, int>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public CriarUsuarioCommandHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<int> Handle(CriarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = new Usuario(request.Nome, request.Sobrenome, request.Email, request.DataNascimento, request.EscolaridadeId);
            usuario.AdicionarHistoricoEscolar(request.File.ContentType, request.File.FileName);

            var fileName = Path.GetFileName(request.File.FileName);

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            using (var localFile = File.OpenWrite(fileName))
            using (var uploadedFile = request.File.OpenReadStream())
            {
                uploadedFile.CopyTo(localFile);
            }

            await _usuarioRepository.Salvar(usuario);

            return usuario.Id;
        }
    }
}
