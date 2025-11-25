using LocadoraDeVeiculos.Aplicacao.ModuloVeiculo.commands.Selecionar;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraDeVeiculos.Aplicacao.ModuloVeiculo.Mappers
{
    public static class AutomovelMapper
    {
    
        public static SelecionarAutomovelDto ToDto(this Automovel automovel)
        {
            return new SelecionarAutomovelDto(
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
        }

        public static IEnumerable<SelecionarAutomovelDto> ToDto(this IEnumerable<Automovel> automoveis)
        {
            return automoveis.Select(a => a.ToDto()).ToList();
        }
    }
}
