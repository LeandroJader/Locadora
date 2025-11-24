using FluentValidation;
using LocadoraDeVeiculos.ModuloFuncionario;

public class ValidadorFuncionario : AbstractValidator<Funcionario>
{
    public ValidadorFuncionario()
    {
     
        RuleFor(f => f.Nome)
            .NotEmpty().WithMessage("O nome é obrigatório")
            .MinimumLength(3).WithMessage("O nome deve ter no mínimo 3 caracteres");

        RuleFor(f => f.Salario)
            .GreaterThan(0).WithMessage("O salário deve ser maior que zero");

    
        RuleFor(f => f.DataAdmissao)
            .Must(data => data <= DateOnly.FromDateTime(DateTime.Today))
            .WithMessage("A data de admissão não pode ser no futuro");
    }
}
