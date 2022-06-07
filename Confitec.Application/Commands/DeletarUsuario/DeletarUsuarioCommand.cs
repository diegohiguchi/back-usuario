﻿using MediatR;

namespace Confitec.Application.Commands.DeletarUsuario
{
    public class DeletarUsuarioCommand : IRequest<Unit>
    {
        public DeletarUsuarioCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
