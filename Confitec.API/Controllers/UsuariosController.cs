using AutoMapper;
using Confitec.Application.Commands.CriarUsuario;
using Confitec.Application.Commands.DeletarUsuario;
using Confitec.Application.Commands.EditarUsuario;
using Confitec.Application.Queries.ObterTodosUsuario;
using Confitec.Application.Queries.ObterUsuario;
using Confitec.Core.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Confitec.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public UsuariosController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var query = new ObterTodosUsuarioQuery();

            var listaUsuarios = _mapper.Map<List<UsuarioDTO>>(await _mediator.Send(query));

            return Ok(listaUsuarios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var query = new ObterUsuarioQuery(id);

            var usuario = await _mediator.Send(query);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromForm] CriarUsuarioCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(ObterPorId), new { id = id }, command);
        }

        [HttpGet("download/{filename}")]
        public async Task<IActionResult> Download(string filename)
        {
            if (filename == null)
                return Content("filepart not present");

            var path = Path.Combine(Directory.GetCurrentDirectory(), filename);

            var memory = new MemoryStream();
            using var stream = new FileStream(path, FileMode.Open);
            await stream.CopyToAsync(memory);

            memory.Position = 0;
            return File(memory, ObterTipoConteudo(path), Path.GetFileName(path));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Editar(int id, [FromForm] EditarUsuarioCommand command)
        {
            await _mediator.Send(command);

            return CreatedAtAction(nameof(ObterPorId), new { id = id }, command);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            var command = new DeletarUsuarioCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

        private string ObterTipoConteudo(string fileName)
        {
            var strcontentType = "application/octetstream";
            var ext = Path.GetExtension(fileName).ToLower();
            Microsoft.Win32.RegistryKey registryKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);

            if (registryKey != null && registryKey.GetValue("Content Type") != null)
                strcontentType = registryKey.GetValue("Content Type").ToString();

            return strcontentType;
        }
    }
}
