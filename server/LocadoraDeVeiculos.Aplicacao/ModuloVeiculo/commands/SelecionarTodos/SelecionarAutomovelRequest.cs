using FluentResults;
using LocadoraDeVeiculos.Aplicacao.ModuloGrupoDeVeiculos.commands.Inserir;
using LocadoraDeVeiculos.Aplicacao.ModuloGrupoDeVeiculos.commands.SelecionarTodos;
using LocadoraDeVeiculos.Aplicacao.ModuloVeiculo.commands.inserir;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Aplicacao.ModuloVeiculo.commands.Selecionar
{
    public record SelecionarAutomovelRequest
  : IRequest<Result<SelecionarAutomovelResponse>>;
    }

