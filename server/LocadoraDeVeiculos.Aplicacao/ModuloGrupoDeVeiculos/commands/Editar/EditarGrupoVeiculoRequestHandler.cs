using FluentResults;
using FluentValidation;
using LocadoraDeVeiculos.Aplicacao.Compartilhado;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using MediatR;

namespace LocadoraDeVeiculos.Aplicacao.ModuloGrupoDeVeiculos.commands.Editar
{
    internal class EditarGrupoVeiculoRequestHandler(
        IRepositorioGrupoDeVeiculos repositorioGrupoVeiculos,
        IContextoPersistencia contexto,
        IValidator<GrupoDeVeiculos> validador
    ) : IRequestHandler<EditarGrupoVeiculoRequest, Result<EditarGrupoVeiculoResponse>>
    {
        public async Task<Result<EditarGrupoVeiculoResponse>> Handle(
            EditarGrupoVeiculoRequest request,
            CancellationToken cancellationToken)
        {
            // Selecionar registro
            var grupoSelecionado = await repositorioGrupoVeiculos.SelecionarPorIdAsync(request.Id);

            if (grupoSelecionado == null)
                return Result.Fail(ErrorResults.NotFoundError(request.Id));

            // Atualizar propriedades
            grupoSelecionado.Nome = request.Nome;

            // Validar entidade
            var resultadoValidacao = await validador.ValidateAsync(grupoSelecionado, cancellationToken);

            if (!resultadoValidacao.IsValid)
            {
                var erros = resultadoValidacao.Errors
                    .Select(failure => failure.ErrorMessage)
                    .ToList();

                return Result.Fail(ErrorResults.BadRequestError(erros));
            }

            // Verificar duplicidade
            var grupos = await repositorioGrupoVeiculos.SelecionarTodosAsync();

            if (NomeDuplicado(grupoSelecionado, grupos))
                return Result.Fail(GrupoVeiculoErrorResults.NomeDuplicadoError(grupoSelecionado.Nome));

            // Persistir alterações
            try
            {
                await repositorioGrupoVeiculos.EditarAsync(grupoSelecionado);
                await contexto.GravarAsync();
            }
            catch (Exception ex)
            {
                await contexto.RollbackAsync();
                return Result.Fail(ErrorResults.InternalServerError(ex));
            }

            return Result.Ok(new EditarGrupoVeiculoResponse(grupoSelecionado.Id));
        }

        private bool NomeDuplicado(GrupoDeVeiculos grupo, IEnumerable<GrupoDeVeiculos> grupos)
        {
            return grupos.Any(registro =>
                registro.Id != grupo.Id &&
                registro.Nome.Equals(grupo.Nome, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
