using AutoMapper;
using Confitec.Application.Queries.ObterTodasEscolaridade;
using Confitec.Application.Queries.ObterEscolaridade;
using Confitec.Core.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Confitec.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EscolaridadesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public EscolaridadesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var query = new ObterTodasEscolaridadeQuery();

            var listaEscolaridades = _mapper.Map<List<EscolaridadeDTO>>(await _mediator.Send(query));

            return Ok(listaEscolaridades);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var query = new ObterEscolaridadeQuery(id);

            var usuario = await _mediator.Send(query);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }
    }
}
