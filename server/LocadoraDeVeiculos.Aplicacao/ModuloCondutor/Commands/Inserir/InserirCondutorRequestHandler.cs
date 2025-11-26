using FluentResults;
using FluentValidation;
using LocadoraDeVeiculos.Aplicacao.Compartilhado;
using LocadoraDeVeiculos.Aplicacao.ModuloCondutor;
using LocadoraDeVeiculos.Aplicacao.ModuloCondutor.Commands.Inserir;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloAutenticacao;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using MediatR;

public class InserirCondutorHandler
        : IRequestHandler<InserirCondutorRequest, Result<InserirCondutorResponse>>
{
    private readonly IContextoPersistencia _contexto;
    private readonly IRepositorioCondutor _repositorio;
    private readonly ITenantProvider _tenantProvider;
    private readonly IValidator<Condutor> _validador;

    public InserirCondutorHandler(
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

    public async Task<Result<InserirCondutorResponse>> Handle(
        InserirCondutorRequest request,
        CancellationToken cancellationToken)
    {
        var condutor = new Condutor(
            request.Nome,
            request.Email,
            request.Cpf,
            request.Cnh,
            request.ValidadeCnh,
            request.Telefone,
            _tenantProvider.UsuarioId.GetValueOrDefault()
        );

        var resultadoValidacao = await _validador.ValidateAsync(condutor, cancellationToken);
        if (!resultadoValidacao.IsValid)
        {
            var erros = resultadoValidacao.Errors.Select(e => e.ErrorMessage).ToList();
            return Result.Fail(erros.Select(msg => new Error(msg)));
        }

        var condutores = await _repositorio.SelecionarTodosAsync();

        if (condutores.Any(c => c.Cpf == condutor.Cpf))
            return Result.Fail(CondutorErrorResults.CpfDuplicado(condutor.Cpf));

        if (condutores.Any(c => c.Cnh == condutor.Cnh))
            return Result.Fail(CondutorErrorResults.CnhDuplicada(condutor.Cnh));

        try
        {
            await _repositorio.InserirAsync(condutor);
            await _contexto.GravarAsync();

            return Result.Ok(new InserirCondutorResponse(condutor.Id));
        }
        catch (System.Exception ex)
        {
            await _contexto.RollbackAsync();
            return Result.Fail(ErrorResults.InternalServerError(ex));
        }
    }
}
