using Confitec.Application.Commands.EditarUsuario;
using Confitec.Core.Entities;
using Confitec.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confitec.Application.Commands.EditarUsuario
{
    public class EditarUsuarioCommandHandler : IRequestHandler<EditarUsuarioCommand, int>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public EditarUsuarioCommandHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<int> Handle(EditarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.ObterPorId(request.Id);

            usuario.AlterarUsuario(request.Nome, request.Sobrenome, request.Email, request.DataNascimento, request.EscolaridadeId);

            if (request.File != null)
            {
                usuario.HistoricoEscolar.AlterarHistoricoEscolar(request.File.ContentType, request.File.FileName);

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
            }

            await _usuarioRepository.SaveChangesAsync();

            return usuario.Id;
        }
    }
}
