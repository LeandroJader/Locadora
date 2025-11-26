using FluentResults;
using LocadoraDeVeiculos.Aplicacao.Compartilhado;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Aplicacao.ModuloGrupoDeVeiculos.commands.Excluir
{
    public record ExcluirGrupoVeiculosRequestHandler(
    IRepositorioGrupoDeVeiculos repositorioGrupoVeiculo,
    IContextoPersistencia contexto
) : IRequestHandler<ExcluirGrupoVeiculoRequest, Result<ExcluirGrupoVeiculoResponse>>
    {
        public async Task<Result<ExcluirGrupoVeiculoResponse>> Handle(ExcluirGrupoVeiculoRequest request, CancellationToken cancellationToken)
        {
            var veiculoSelecionado = await repositorioGrupoVeiculo.SelecionarPorIdAsync(request.Id);

            if (veiculoSelecionado is null)
                return Result.Fail(ErrorResults.NotFoundError(request.Id));

            try
            {
                await repositorioGrupoVeiculo.ExcluirAsync(veiculoSelecionado);

                await contexto.GravarAsync();
            }
            catch (Exception ex)
            {
                await contexto.RollbackAsync();

                return Result.Fail(ErrorResults.InternalServerError(ex));
            }

            return Result.Ok(new ExcluirGrupoVeiculoResponse());
        }
    };
    
    
}
