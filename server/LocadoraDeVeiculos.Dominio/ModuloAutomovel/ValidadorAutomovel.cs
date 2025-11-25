using FluentValidation;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;

namespace LocadoraDeVeiculos.Dominio.ModuloAutomovel
{
    public class ValidadorAutomovel : AbstractValidator<Automovel>
    {
        public ValidadorAutomovel()
        {
            RuleFor(a => a.Placa)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                .Length(7, 8).WithMessage("O campo {PropertyName} deve conter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(a => a.Marca)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                .MinimumLength(2).WithMessage("O campo {PropertyName} deve conter no mínimo {MinLength} caracteres");

            RuleFor(a => a.Modelo)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório");

            RuleFor(a => a.Cor)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório");

            RuleFor(a => a.TipoCombustivel)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório");

            RuleFor(a => a.CapacidadeTanque)
                .GreaterThan(0).WithMessage("O campo {PropertyName} deve ser maior que zero");

            RuleFor(a => a.Ano)
                .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Now))
                .WithMessage("O campo {PropertyName} não pode ser maior que o ano atual");

            RuleFor(a => a.Foto)
                .NotNull().WithMessage("O campo {PropertyName} é obrigatório");
        }
    }
}
