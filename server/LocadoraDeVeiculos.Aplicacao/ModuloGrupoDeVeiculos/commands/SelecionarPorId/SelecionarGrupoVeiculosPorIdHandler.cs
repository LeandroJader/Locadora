using FluentResults;
using MediatR;
using LocadoraDeVeiculos.Aplicacao.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;

namespace LocadoraDeVeiculos.Aplicacao.ModuloGrupoDeVeiculos.Commands.SelecionarPorId;

public class SelecionarGrupoVeiculoPorIdRequestHandler(
    IRepositorioGrupoDeVeiculos repositorioGrupoVeiculos
) : IRequestHandler<SelecionarGrupoVeiculoPorIdRequest, Result<SelecionarGrupoVeiculoPorIdResponse>>
{
    public async Task<Result<SelecionarGrupoVeiculoPorIdResponse>> Handle(
        SelecionarGrupoVeiculoPorIdRequest request,
        CancellationToken cancellationToken)
    {
        var grupo = await repositorioGrupoVeiculos.SelecionarPorIdAsync(request.Id);

        if (grupo is null)
            return Result.Fail(ErrorResults.NotFoundError(request.Id));

        var resposta = new SelecionarGrupoVeiculoPorIdResponse(
            grupo.Id,
            grupo.Nome
        );

        return Result.Ok(resposta);
    }
}
