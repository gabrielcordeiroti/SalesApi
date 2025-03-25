using FluentValidation;
using SalesApi.Domain.Entities;

namespace MyTestSalesApi.Validations
{
    public class SaleValidator : AbstractValidator<Sale>
    {
        public SaleValidator()
        {
            RuleFor(s => s.SaleNumber)
                .NotEmpty()
                .Length(2, 20)
                .WithMessage("O número da venda é obrigatório e deve ter entre 2 e 20 caracteres.");

            RuleFor(s => s.SaleDate)
                .NotEmpty()
                .WithMessage("A data da venda é obrigatória.");

            RuleFor(s => s.CustomerId)
                .NotEmpty()
                .WithMessage("O identificador do cliente é obrigatório.");

            RuleFor(s => s.BranchId)
                .NotEmpty()
                .WithMessage("O identificador da filial é obrigatório.");

            RuleFor(s => s.TotalAmount)
                .GreaterThan(0)
                .WithMessage("O valor total da venda deve ser maior que zero.");

            RuleFor(s => s.Items)
                .NotEmpty()
                .WithMessage("A venda deve conter pelo menos um item.");
        }
    }
}
