using Confitec.Core.Repositories;
using MediatR;

namespace Confitec.Application.Commands.DeletarUsuario
{
    public class DeletarUsuarioCommandHandler : IRequestHandler<DeletarUsuarioCommand, Unit>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IHistoricoEscolarRepository _historicoEscolarRepository;

        public DeletarUsuarioCommandHandler(IUsuarioRepository usuarioRepository, IHistoricoEscolarRepository historicoEscolarRepository)
        {
            _usuarioRepository = usuarioRepository;
            _historicoEscolarRepository = historicoEscolarRepository;
        }

        public async Task<Unit> Handle(DeletarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.ObterPorId(request.Id);
            var historicoEscolar = await _historicoEscolarRepository.ObterPorId(usuario.HistoricoEscolarId);

            var fileName = Path.GetFileName(usuario.HistoricoEscolar.Nome);

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            await _usuarioRepository.Deletar(usuario);
            await _historicoEscolarRepository.Deletar(historicoEscolar);

            return Unit.Value;
        }
    }
}
