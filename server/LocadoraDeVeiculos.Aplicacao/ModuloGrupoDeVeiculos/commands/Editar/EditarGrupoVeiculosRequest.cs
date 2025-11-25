using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Aplicacao.ModuloGrupoDeVeiculos.commands.Editar
{
    public record EditarGrupoVeiculoPartialRequest(string Nome);

    public record EditarGrupoVeiculoRequest(Guid Id, string Nome) : IRequest<Result<EditarGrupoVeiculoResponse>>;

}
