using Confitec.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confitec.Application.Queries.ObterEscolaridade
{
    public class ObterEscolaridadeQuery : IRequest<EscolaridadeViewModel>
    {
        public ObterEscolaridadeQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
