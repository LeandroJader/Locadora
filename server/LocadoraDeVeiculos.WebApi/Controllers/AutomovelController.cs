using FluentResults;
using LocadoraDeVeiculos.Aplicacao.ModuloVeiculo.commands.editar;
using LocadoraDeVeiculos.Aplicacao.ModuloVeiculo.commands.Excluir;
using LocadoraDeVeiculos.Aplicacao.ModuloVeiculo.commands.inserir;
using LocadoraDeVeiculos.Aplicacao.ModuloVeiculo.commands.Selecionar;
using LocadoraDeVeiculos.Aplicacao.ModuloVeiculo.commands.SelecionarPorId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraDeVeiculos.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutomovelController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AutomovelController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/automovel
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var resultado = await _mediator.Send(new SelecionarAutomovelRequest());

            if (resultado.IsFailed)
                return BadRequest(resultado.Errors);

            return Ok(resultado.Value);
        }

        // GET: api/automovel/{id}
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var resultado = await _mediator.Send(new SelecionarAutomovelPorIdRequest(id));

            if (resultado.IsFailed)
                return NotFound(resultado.Errors);

            return Ok(resultado.Value);
        }

        // POST: api/automovel
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] InserirAutomovelRequest request)
        {
            var resultado = await _mediator.Send(request);

            if (resultado.IsFailed)
                return BadRequest(resultado.Errors);

            return CreatedAtAction(nameof(GetById), new { id = resultado.Value.Id }, resultado.Value);
        }

        // PUT: api/automovel/{id}
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] EditarAutomovelRequest request)
        {
            if (id != request.Id)
                return BadRequest("O ID do URL e do corpo da requisição não coincidem.");

            var resultado = await _mediator.Send(request);

            if (resultado.IsFailed)
                return BadRequest(resultado.Errors);

            return Ok(resultado.Value);
        }

        // DELETE: api/automovel/{id}
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var resultado = await _mediator.Send(new ExcluirAutomovelRequest(id));

            if (resultado.IsFailed)
                return BadRequest(resultado.Errors);

            return NoContent();
        }
    }
}
