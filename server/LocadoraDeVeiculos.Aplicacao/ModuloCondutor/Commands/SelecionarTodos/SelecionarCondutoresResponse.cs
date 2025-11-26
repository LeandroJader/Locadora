namespace LocadoraDeVeiculos.Aplicacao.ModuloCondutor.Commands.SelecionarTodos
{
    public record SelecionarCondutorDto(Guid Id, string Nome, string Cpf, string Email);

    public record SelecionarCondutoresResponse
    {
        public required int QuantidadeRegistros { get; init; }
        public required IEnumerable<SelecionarCondutorDto> Registros { get; init; }
    }
}
