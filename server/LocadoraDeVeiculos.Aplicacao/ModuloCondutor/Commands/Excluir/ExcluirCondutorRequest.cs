using FluentResults;
using MediatR;
using System;

namespace LocadoraDeVeiculos.Aplicacao.ModuloCondutor.Commands.Excluir
{
    public record ExcluirCondutorRequest(Guid Id) : IRequest<Result<ExcluirCondutorResponse>>;
}
