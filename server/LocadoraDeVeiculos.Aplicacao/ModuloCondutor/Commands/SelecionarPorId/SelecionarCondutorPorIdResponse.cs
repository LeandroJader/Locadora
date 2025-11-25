namespace LocadoraDeVeiculos.Aplicacao.ModuloCondutor.Commands.SelecionarPorId
{
    public record SelecionarCondutorPorIdResponse(
        Guid Id,
        string Nome,
        string Cpf,
        string Cnh,
        DateOnly ValidadeCnh,
        string Email,
        string Telefone,
        Guid usuarioId
    );
}
