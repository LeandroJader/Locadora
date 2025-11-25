using System;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Aplicacao.ModuloVeiculo.commands.Selecionar
{
    public record SelecionarAutomovelDto(
        Guid Id,
        string Placa,
        string Marca,
        string Modelo,
        string Cor,
        string TipoCombustivel,
        decimal CapacidadeTanque,
        DateOnly Ano,
        Guid GrupoVeiculosId
    );

    public record SelecionarAutomovelResponse
    {
        public required int QuantidadeRegistros { get; init; }
        public required IEnumerable<SelecionarAutomovelDto> Registros { get; init; }
    }
}
