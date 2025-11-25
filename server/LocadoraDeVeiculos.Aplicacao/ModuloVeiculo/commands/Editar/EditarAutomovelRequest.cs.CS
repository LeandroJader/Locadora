using FluentResults;
using LocadoraDeVeiculos.Aplicacao.ModuloGrupoDeVeiculos.commands.Editar;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Aplicacao.ModuloVeiculo.commands.editar
{
    public record EditarAutomovelpartialRequest(
        string placa, string marca, string cor, 
        string modelo, string tipoCombustivel, decimal capacidadeTanque, DateOnly ano,
        byte[] foto,
        Guid grupoVeiculoId);

    public record EditarAutomovelRequest(Guid Id, string placa, string marca, string cor,
        string modelo, string tipoCombustivel, decimal capacidadeTanque, DateOnly ano,
        byte[] foto,
        Guid grupoVeiculoId) : IRequest<Result<EditarAutomovelResponse>>;
}
