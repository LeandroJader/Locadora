using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Aplicacao.ModuloVeiculo.commands.Selecionar
{
    public record SelecionarAutomovelRequestHandler(
        IRepositorioAutomovel repositorioVeiculo
    ) : IRequestHandler<SelecionarAutomovelRequest, Result<SelecionarAutomovelResponse>>
    {
        public async Task<Result<SelecionarAutomovelResponse>> Handle(
            SelecionarAutomovelRequest request, CancellationToken cancellationToken)
        {
            var registros = await repositorioVeiculo.SelecionarTodosAsync();

            var response = new SelecionarAutomovelResponse
            {
                QuantidadeRegistros = registros.Count,
                Registros = registros
                    .Select(r => new SelecionarAutomovelDto(
                        r.Id,
                        r.Placa,
                        r.Marca,
                        r.Modelo,
                        r.Cor,
                        r.TipoCombustivel,
                        r.CapacidadeTanque,
                        r.Ano,
                        r.GrupoVeiculosId
                    ))
                    .ToList()
            };

            return Result.Ok(response);
        }
    }
}
