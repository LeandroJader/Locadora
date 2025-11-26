using FluentResults;
using FluentValidation;
using LocadoraDeVeiculos.Aplicacao.Compartilhado;
using LocadoraDeVeiculos.Aplicacao.ModuloCondutor;
using LocadoraDeVeiculos.Aplicacao.ModuloCondutor.Commands.Editar;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloAutenticacao;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Aplicacao.ModuloCondutor.Commands.Editar
{
    public class EditarCondutorHandler : IRequestHandler<EditarCondutorRequest, Result<EditarCondutorResponse>>
    {
        private readonly IContextoPersistencia _contexto;
        private readonly IRepositorioCondutor _repositorio;
        private readonly ITenantProvider _tenantProvider;
        private readonly IValidator<Condutor> _validador;

        public EditarCondutorHandler(
            IContextoPersistencia contexto,
            IRepositorioCondutor repositorio,
            ITenantProvider tenantProvider,
            IValidator<Condutor> validador)
        {
            _contexto = contexto;
            _repositorio = repositorio;
            _tenantProvider = tenantProvider;
            _validador = validador;
        }

        public async Task<Result<EditarCondutorResponse>> Handle(
            EditarCondutorRequest request,
            CancellationToken cancellationToken)
        {

            var condutor = await _repositorio.SelecionarPorIdAsync(request.Id);

            if (condutor is null)
                return Result.Fail(CondutorErrorResults.CondutorInexistente(request.Id));

      
            condutor.Nome = request.Nome;
            condutor.Email = request.Email;
            condutor.Cpf = request.Cpf;
            condutor.Cnh = request.Cnh;
            condutor.ValidadeCnh = request.ValidadeCnh;
            condutor.Telefone = request.Telefone;

            condutor.UsuarioId = _tenantProvider.UsuarioId.GetValueOrDefault();


            var resultadoValidacao = await _validador.ValidateAsync(condutor, cancellationToken);
            if (!resultadoValidacao.IsValid)
            {
                var erros = resultadoValidacao.Errors.Select(e => e.ErrorMessage).ToList();
                return Result.Fail(erros.Select(msg => new Error(msg)));
            }

            var condutoresRegistrados = await _repositorio.SelecionarTodosAsync();

            if (condutoresRegistrados.Any(c => c.Cpf == condutor.Cpf && c.Id != condutor.Id))
                return Result.Fail(CondutorErrorResults.CpfDuplicado(condutor.Cpf));

            if (condutoresRegistrados.Any(c => c.Cnh == condutor.Cnh && c.Id != condutor.Id))
                return Result.Fail(CondutorErrorResults.CnhDuplicada(condutor.Cnh));

            try
            {
                await _repositorio.EditarAsync(condutor);
                await _contexto.GravarAsync();

                return Result.Ok(new EditarCondutorResponse(condutor.Id));
            }
            catch (System.Exception ex)
            {
                await _contexto.RollbackAsync();
                return Result.Fail(ErrorResults.InternalServerError(ex));
            }
        }
    }
}
