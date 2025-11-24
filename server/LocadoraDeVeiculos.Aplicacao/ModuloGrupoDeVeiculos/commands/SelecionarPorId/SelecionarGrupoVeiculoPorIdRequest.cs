using FluentResults;
using MediatR;

namespace LocadoraDeVeiculos.Aplicacao.ModuloGrupoDeVeiculos.Commands.SelecionarPorId;

public record SelecionarGrupoVeiculoPorIdRequest(Guid Id)
    : IRequest<Result<SelecionarGrupoVeiculoPorIdResponse>>;
