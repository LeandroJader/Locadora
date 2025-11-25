using FluentResults;
using FluentValidation;
using LocadoraDeVeiculos.Aplicacao.Compartilhado;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloAutenticacao;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Aplicacao.ModuloGrupoDeVeiculos.commands.Inserir
{
    internal class InserirGrupoVeiculoHandler(
    IContextoPersistencia contexto,
    IRepositorioGrupoDeVeiculos repositorioGrupoVeiculo,
    ITenantProvider tenantProvider,
    IValidator<GrupoDeVeiculos> validador
) : IRequestHandler<InserirGrupoVeiculoRequest, Result<InserirGrupoVeiculoResponse>>
    {
        public async Task<Result<InserirGrupoVeiculoResponse>> Handle(InserirGrupoVeiculoRequest request, CancellationToken cancellationToken)
        {
            var GrupoVeiculo = new GrupoDeVeiculos(request.Nome)
            {
                UsuarioId = tenantProvider.UsuarioId.GetValueOrDefault()
            };

            var resultadoValidacao = await validador.ValidateAsync(GrupoVeiculo);

            if (!resultadoValidacao.IsValid)
            {
                var erros = resultadoValidacao.Errors
                    .Select(failure => failure.ErrorMessage)
                    .ToList();

                return Result.Fail(ErrorResults.BadRequestError(erros));
            }

            var veiculosRegistrados = await repositorioGrupoVeiculo.SelecionarTodosAsync();

            if (NomeDuplicado(GrupoVeiculo, veiculosRegistrados))
                return Result.Fail(GrupoVeiculoErrorResults.NomeDuplicadoError(GrupoVeiculo.Nome));

            try
            {
                await repositorioGrupoVeiculo.InserirAsync(GrupoVeiculo);

                await contexto.GravarAsync();
            }
            catch (Exception ex)
            {
                await contexto.RollbackAsync();

                return Result.Fail(ErrorResults.InternalServerError(ex));
            }

            return Result.Ok(new InserirGrupoVeiculoResponse(GrupoVeiculo.Id));
        }

        private bool NomeDuplicado(GrupoDeVeiculos veiculo, IEnumerable<GrupoDeVeiculos> veiculos)
        {
            return veiculos
                .Any(registro => string.Equals(
                    registro.Nome   ,
                    veiculo.Nome,
                    StringComparison.CurrentCultureIgnoreCase)
                );
        }
    
    }
}
