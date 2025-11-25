using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Aplicacao.ModuloGrupoDeVeiculos.commands.Inserir
{
    public record InserirGrupoVeiculoRequest(string Nome) : IRequest<Result<InserirGrupoVeiculoResponse>>;
}
