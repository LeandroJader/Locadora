using FluentResults;
using MediatR;

namespace LocadoraDeVeiculos.Aplicacao.ModuloCondutor.Commands.Inserir
{
    public record InserirCondutorRequest(
        string Nome,
        string Email,
        string Cpf,
        string Cnh,
        DateOnly ValidadeCnh,
        string Telefone)
        : IRequest<Result<InserirCondutorResponse>>;
}
