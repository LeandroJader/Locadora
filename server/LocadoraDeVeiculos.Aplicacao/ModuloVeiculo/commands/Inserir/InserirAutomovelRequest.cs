using FluentResults;
using LocadoraDeVeiculos.Aplicacao.ModuloGrupoDeVeiculos.commands.Inserir;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using MediatR;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Aplicacao.ModuloVeiculo.commands.inserir
{
    public record InserirAutomovelRequest(string placa, string marca, string cor, string modelo,
        string tipoCombustivel, decimal capacidadeTanque,
        DateOnly ano, byte[] foto, Guid GrupoVeiculosId)
        : IRequest<Result<InseririAutomovelResponse>>;
}
