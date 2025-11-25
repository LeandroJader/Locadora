using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LocadoraDeVeiculos.Aplicacao.ModuloGrupoDeVeiculos.Commands.SelecionarPorId;
using LocadoraDeVeiculos.Aplicacao.ModuloGrupoDeVeiculos.commands.SelecionarTodos;
using LocadoraDeVeiculos.WebApi.Extensions;
using LocadoraDeVeiculos.Aplicacao.ModuloGrupoDeVeiculos.commands.Inserir;
using LocadoraDeVeiculos.Aplicacao.ModuloGrupoDeVeiculos.commands.Editar;
using LocadoraDeVeiculos.Aplicacao.ModuloGrupoDeVeiculos.commands.Excluir;

namespace LocadoraDeVeiculos.WebApi.Controllers;

[ApiController]
[Authorize]
[Route("api/grupos-veiculos")]
public class GrupoVeiculosController(IMediator mediator) : ControllerBase
{
    // POST: api/grupos-veiculos
    [HttpPost]
    [ProducesResponseType(typeof(InserirGrupoVeiculoResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Inserir(InserirGrupoVeiculoRequest request)
    {
        var resultado = await mediator.Send(request);

        return resultado.ToHttpResponse();
    }

    // PUT: api/grupos-veiculos/{id}
    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(EditarGrupoVeiculoResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Editar(Guid id, EditarGrupoVeiculoPartialRequest request)
    {
        var editarRequest = new EditarGrupoVeiculoRequest(
            id,
            request.Nome

        );

        var resultado = await mediator.Send(editarRequest);

        return resultado.ToHttpResponse();
    }

    // DELETE: api/grupos-veiculos/{id}
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(typeof(ExcluirGrupoDeVeiculoResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Excluir(Guid id)
    {
        var excluirRequest = new ExcluirGrupoVeiculoRequest(id);

        var resultado = await mediator.Send(excluirRequest);

        return resultado.ToHttpResponse();
    }

    // GET: api/grupos-veiculos
    [HttpGet]
    [ProducesResponseType(typeof(SelecionarGrupoVeiculosResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> SelecionarTodos()
    {
        var resultado = await mediator.Send(new SelecionarGrupoVeiculoRequest());

        return resultado.ToHttpResponse();
    }

    // GET: api/grupos-veiculos/{id}
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(SelecionarGrupoVeiculoPorIdResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> SelecionarPorId(Guid id)
    {
        var selecionarPorIdRequest = new SelecionarGrupoVeiculoPorIdRequest(id);

        var resultado = await mediator.Send(selecionarPorIdRequest);

        return resultado.ToHttpResponse();
    }
}
