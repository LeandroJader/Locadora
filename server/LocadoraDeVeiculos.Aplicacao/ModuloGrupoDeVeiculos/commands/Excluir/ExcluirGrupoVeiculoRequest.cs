using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Aplicacao.ModuloGrupoDeVeiculos.commands.Excluir
{
    public record ExcluirGrupoVeiculoRequest(Guid Id) : IRequest<Result<ExcluirGrupoVeiculoResponse>>;
}
