using FluentResults;
using LocadoraDeVeiculos.Aplicacao.ModuloGrupoDeVeiculos.commands.SelecionarTodos;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using MediatR;

public class SelecionarGrupoVeiculosRequestHandler(
    IRepositorioGrupoDeVeiculos repositorioGrupoVeiculo
) : IRequestHandler<SelecionarGrupoVeiculoRequest, Result<SelecionarGrupoVeiculosResponse>>
{
    public async Task<Result<SelecionarGrupoVeiculosResponse>> Handle(
        SelecionarGrupoVeiculoRequest request, CancellationToken cancellationToken)
    {
        var registros = await repositorioGrupoVeiculo.SelecionarTodosAsync();

        var response = new SelecionarGrupoVeiculosResponse
        {
            QuantidadeRegistros = registros.Count,
            Registros = registros
                .Select(r => new SelecionarGrupoVeiculosDto(r.Id, r.Nome))
                .ToList()
        };

        return Result.Ok(response);
    }
}
