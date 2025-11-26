using FluentResults;
using LocadoraDeVeiculos.Aplicacao.ModuloCondutor.Commands.SelecionarTodos;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using MediatR;

public class SelecionarCondutoresRequestHandler(
    IRepositorioCondutor repositorioCondutor
) : IRequestHandler<SelecionarCondutoresRequest, Result<SelecionarCondutoresResponse>>
{
    public async Task<Result<SelecionarCondutoresResponse>> Handle(
        SelecionarCondutoresRequest request, CancellationToken cancellationToken)
    {
        var registros = await repositorioCondutor.SelecionarTodosAsync();

        var response = new SelecionarCondutoresResponse
        {
            QuantidadeRegistros = registros.Count,
            Registros = registros
                .Select(r => new SelecionarCondutorDto(
                    r.Id,
                    r.Nome,
                    r.Cpf,
                    r.Email
                ))
                .ToList()
        };

        return Result.Ok(response);
    }
}
