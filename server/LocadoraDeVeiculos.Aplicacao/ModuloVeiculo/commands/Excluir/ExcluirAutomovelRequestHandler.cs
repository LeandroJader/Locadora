using FluentResults;
using LocadoraDeVeiculos.Aplicacao.Compartilhado;
using LocadoraDeVeiculos.Aplicacao.ModuloGrupoDeVeiculos.commands.Excluir;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Aplicacao.ModuloVeiculo.commands.Excluir
{
    public record ExcluirAutomovelRequestHandler(
    IRepositorioAutomovel repositorVeiculo,
    IContextoPersistencia contexto
) : IRequestHandler<ExcluirAutomovelRequest, Result<ExcluirAutomovelResponse>>
    {
        public async Task<Result<ExcluirAutomovelResponse>> Handle(ExcluirAutomovelRequest request, CancellationToken cancellationToken)
        {
            var veiculoSelecionado = await repositorVeiculo.SelecionarPorIdAsync(request.Id);

            if (veiculoSelecionado is null)
                return Result.Fail(ErrorResults.NotFoundError(request.Id));

            try
            {
                await repositorVeiculo.ExcluirAsync(veiculoSelecionado);

                await contexto.GravarAsync();
            }
            catch (Exception ex)
            {
                await contexto.RollbackAsync();

                return Result.Fail(ErrorResults.InternalServerError(ex));
            }

            return Result.Ok(new ExcluirAutomovelResponse());
        }
    };


}

