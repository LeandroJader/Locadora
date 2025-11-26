using FluentValidation;

namespace LocadoraDeVeiculos.Dominio.ModuloCondutor
{
    public class ValidadorCondutor : AbstractValidator<Condutor>
    {
        public ValidadorCondutor()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                .MinimumLength(3).WithMessage("O campo {PropertyName} deve conter no mínimo {MinLength} caracteres");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                .EmailAddress().WithMessage("O campo {PropertyName} deve conter um e-mail válido");

            RuleFor(c => c.Cpf)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                .Length(11).WithMessage("O campo {PropertyName} deve conter exatamente {MaxLength} dígitos")
                .Matches("^[0-9]*$").WithMessage("O campo {PropertyName} deve conter apenas números");

            RuleFor(c => c.Cnh)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                .Length(11).WithMessage("O campo {PropertyName} deve conter exatamente {MaxLength} dígitos")
                .Matches("^[0-9]*$").WithMessage("O campo {PropertyName} deve conter apenas números");

            RuleFor(c => c.ValidadeCnh)
                .Must(SerDataFutura)
                .WithMessage("A CNH deve estar dentro da validade");

            RuleFor(c => c.Telefone)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                .Matches(@"^\(?\d{2}\)?\s?\d{4,5}-?\d{4}$")
                .WithMessage("O campo {PropertyName} deve conter um telefone válido (ex: (49) 99999-9999)");
        }

        private bool SerDataFutura(DateOnly data)
        {
            return data >= DateOnly.FromDateTime(DateTime.Now);
        }
    }
}
