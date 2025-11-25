using FluentResults;

namespace LocadoraDeVeiculos.Aplicacao.ModuloAutomovel
{
    public abstract class AutomovelErrorResults
    {
        public static Error PlacaDuplicada(string placa)
        {
            return new Error("Placa duplicada")
                .CausedBy($"Um automóvel com a placa '{placa}' já está cadastrado")
                .WithMetadata("ErrorType", "BadRequest");
        }

        public static Error AnoFuturo(DateOnly ano)
        {
            return new Error("Ano inválido")
                .CausedBy($"O ano '{ano}' não pode ser futuro")
                .WithMetadata("ErrorType", "BadRequest");
        }

        public static Error GrupoVeiculoInexistente(Guid grupoVeiculosId)
        {
            return new Error("Grupo de veículos inexistente")
                .CausedBy($"Não existe grupo de veículos com o Id '{grupoVeiculosId}'")
                .WithMetadata("ErrorType", "BadRequest");
        }

        public static Error AutomovelEmAluguel(string placa)
        {
            return new Error("Automóvel em aluguel ativo")
                .CausedBy($"O automóvel com a placa '{placa}' não pode ser editado ou excluído pois está em um aluguel ainda não concluído")
                .WithMetadata("ErrorType", "BadRequest");
        }
    }
}
