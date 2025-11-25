using FluentResults;
using LocadoraDeVeiculos.Aplicacao.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Aplicacao.ModuloVeiculo.commands.SelecionarPorId
{
    public record SelecionarAutomovelPorIdRequestHandler(
        IRepositorioAutomovel repositorioAutomovel
    ) : IRequestHandler<SelecionarAutomovelPorIdRequest, Result<SelecionarAutomovelPorIdResponse>>
    {
        public async Task<Result<SelecionarAutomovelPorIdResponse>> Handle(
            SelecionarAutomovelPorIdRequest request,
            CancellationToken cancellationToken)
        {
            var automovel = await repositorioAutomovel.SelecionarPorIdAsync(request.Id);

            if (automovel is null)
                return Result.Fail(ErrorResults.NotFoundError(request.Id));

            var resposta = new SelecionarAutomovelPorIdResponse(
                automovel.Id,
                automovel.Placa,
                automovel.Marca,
                automovel.Modelo,
                automovel.Cor,
                automovel.TipoCombustivel,
                automovel.CapacidadeTanque,
                automovel.Ano,
                automovel.GrupoVeiculosId
            );

            return Result.Ok(resposta);
        }
    }
}
