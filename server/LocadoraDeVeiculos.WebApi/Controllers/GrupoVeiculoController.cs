using LocadoraDeVeiculos.Aplicacao.ModuloCondutor.Commands.Editar;
using LocadoraDeVeiculos.Aplicacao.ModuloCondutor.Commands.Excluir;
using LocadoraDeVeiculos.Aplicacao.ModuloCondutor.Commands.Inserir;
using LocadoraDeVeiculos.Aplicacao.ModuloCondutor.Commands.SelecionarPorId;
using LocadoraDeVeiculos.Aplicacao.ModuloCondutor.Commands.SelecionarTodos;
using LocadoraDeVeiculos.Aplicacao.ModuloGrupoDeVeiculos.commands.Editar;
using LocadoraDeVeiculos.Aplicacao.ModuloGrupoDeVeiculos.commands.Excluir;
using LocadoraDeVeiculos.Aplicacao.ModuloGrupoDeVeiculos.commands.Inserir;
using LocadoraDeVeiculos.Aplicacao.ModuloGrupoDeVeiculos.commands.SelecionarTodos;
using LocadoraDeVeiculos.Aplicacao.ModuloGrupoDeVeiculos.Commands.SelecionarPorId;
using LocadoraDeVeiculos.WebApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraDeVeiculos.WebApi.Controllers;

[ApiController]
[Authorize]
[Route("api/grupos-veiculos")]
public class GrupoVeiculoController(IMediator mediator) : ControllerBase
{


    [HttpPost]
    [ProducesResponseType(typeof(InserirGrupoVeiculoResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Inserir(InserirGrupoVeiculoRequest request)
    {
        var resultado = await mediator.Send(request);

        return resultado.ToHttpResponse();
    }

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
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(typeof(ExcluirGrupoVeiculoResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Excluir(Guid id)
    {
        var excluirRequest = new ExcluirGrupoVeiculoRequest(id);

        var resultado = await mediator.Send(excluirRequest);

        return resultado.ToHttpResponse();
    }

    [HttpGet]
    [ProducesResponseType(typeof(SelecionarGrupoVeiculosResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> SelecionarTodos()
    {
        var resultado = await mediator.Send(new SelecionarGrupoVeiculoRequest());

        return resultado.ToHttpResponse();
    }



    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(SelecionarGrupoVeiculosResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> SelecionarPorId(Guid id)
    {
        var selecionarPorIdRequest = new SelecionarGrupoVeiculoPorIdRequest(id);

        var resultado = await mediator.Send(selecionarPorIdRequest);

        return resultado.ToHttpResponse();
    }
}

