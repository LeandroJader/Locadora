using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Aplicacao.ModuloGrupoDeVeiculos.commands.SelecionarTodos
{
    public record SelecionarGrupoVeiculoRequest
  : IRequest<Result<SelecionarGrupoVeiculosResponse>>;
}
