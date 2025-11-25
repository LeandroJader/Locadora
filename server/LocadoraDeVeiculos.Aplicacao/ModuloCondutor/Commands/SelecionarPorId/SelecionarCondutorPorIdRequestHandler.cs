using FluentResults;
using LocadoraDeVeiculos.Aplicacao.Compartilhado;
using LocadoraDeVeiculos.Aplicacao.ModuloCondutor.Commands.SelecionarPorId;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Aplicacao.ModuloVeiculo.commands.SelecionarPorId
{
    public record SelecionarCondutorRequestHandler(
        IRepositorioCondutor repositorioCondutor
    ) : IRequestHandler<SelecionarCondutorPorIdRequest, Result<SelecionarCondutorPorIdResponse>>
    {
        public async Task<Result<SelecionarCondutorPorIdRequest>> Handle(
            SelecionarAutomovelPorIdRequest request,
            CancellationToken cancellationToken)
        {
            var condutor = await repositorioCondutor.SelecionarPorIdAsync(request.Id);

            if (condutor is null)
                return Result.Fail(ErrorResults.NotFoundError(request.Id));

            var resposta = new SelecionarAutomovelPorIdResponse(
                condutor.Id,
             
            );

            return Result.Ok(resposta);
        }
    }
}
