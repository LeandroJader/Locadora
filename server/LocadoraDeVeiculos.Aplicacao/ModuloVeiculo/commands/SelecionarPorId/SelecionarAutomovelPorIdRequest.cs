using FluentResults;
using MediatR;
using System;

namespace LocadoraDeVeiculos.Aplicacao.ModuloVeiculo.commands.SelecionarPorId
{
    public record SelecionarAutomovelPorIdRequest(Guid Id)
        : IRequest<Result<SelecionarAutomovelPorIdResponse>>;
}
