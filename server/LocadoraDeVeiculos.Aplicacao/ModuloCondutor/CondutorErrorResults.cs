using FluentResults;

namespace LocadoraDeVeiculos.Aplicacao.ModuloCondutor
{
    public abstract class CondutorErrorResults
    {
        public static Error CpfDuplicado(string cpf)
        {
            return new Error("CPF duplicado")
                .CausedBy($"Já existe um condutor cadastrado com o CPF '{cpf}'")
                .WithMetadata("ErrorType", "BadRequest");
        }

        public static Error CnhDuplicada(string cnh)
        {
            return new Error("CNH duplicada")
                .CausedBy($"Já existe um condutor cadastrado com a CNH '{cnh}'")
                .WithMetadata("ErrorType", "BadRequest");
        }

        public static Error CondutorInexistente(Guid condutorId)
        {
            return new Error("Condutor inexistente")
                .CausedBy($"Não existe condutor com o Id '{condutorId}'")
                .WithMetadata("ErrorType", "BadRequest");
        }

        public static Error CnhInvalida(string validade)
        {
            return new Error("CNH inválida")
                .CausedBy($"A validade da CNH '{validade}' já expirou ou é inválida")
                .WithMetadata("ErrorType", "BadRequest");
        }

        public static Error CondutorEmAluguel(string nome)
        {
            return new Error("Condutor vinculado a aluguel ativo")
                .CausedBy($"O condutor '{nome}' não pode ser editado ou excluído pois está vinculado a um aluguel ainda não concluído")
                .WithMetadata("ErrorType", "BadRequest");
        }
    }
}
