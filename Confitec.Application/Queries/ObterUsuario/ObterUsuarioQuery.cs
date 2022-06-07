using Confitec.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confitec.Application.Queries.ObterUsuario
{
    public class ObterUsuarioQuery : IRequest<UsuarioViewModel>
    {
        public ObterUsuarioQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
