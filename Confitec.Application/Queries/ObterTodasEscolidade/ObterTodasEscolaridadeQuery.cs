using Confitec.Application.ViewModels;
using Confitec.Core.DTOs;
using Confitec.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confitec.Application.Queries.ObterTodasEscolaridade
{
    public class ObterTodasEscolaridadeQuery : IRequest<List<Escolaridade>>
    {
    }
}
