using FluentResults;
using LocadoraDeVeiculos.Aplicacao.ModuloGrupoDeVeiculos.Commands.SelecionarPorId;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Aplicacao.ModuloVeiculo.commands.SelecionarPorId
{
    internal class SelecionarAutomovelPorIdRequest(Guid Id)
    : IRequest<Result<SelecionarAutomovelPorIdResponse>>;
    {
    }
}
