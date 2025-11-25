using System;

namespace LocadoraDeVeiculos.Aplicacao.ModuloVeiculo.commands.SelecionarPorId
{
    public record SelecionarAutomovelPorIdResponse(
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
}
