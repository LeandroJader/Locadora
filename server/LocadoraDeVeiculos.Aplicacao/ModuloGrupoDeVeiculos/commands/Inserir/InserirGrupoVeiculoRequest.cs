using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Aplicacao.ModuloGrupoDeVeiculos.commands.Inserir
{
    public record InseririGrupoVeiculoRequest(string Nome) : IRequest<Result<InserirGrupoVeiculoResponse>>;
}
