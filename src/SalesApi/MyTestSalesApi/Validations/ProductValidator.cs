using FluentValidation;
using SalesApi.Domain.Entities;

namespace MyTestSalesApi.Validations
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty()
                .Length(3, 100)
                .WithMessage("O título do produto é obrigatório e deve ter pelo menos 3 caracteres e no máximo 100.");

            RuleFor(p => p.Price)
                .GreaterThan(0)
                .WithMessage("O preço do produto deve ser maior que zero.");

            RuleFor(p => p.Description)
                .NotEmpty()
                .Length(3, 100)
                .WithMessage("A descrição do produto é obrigatória e deve ter pelo menos 3 caracteres e no máximo 100.");

            RuleFor(p => p.Category)
                .NotEmpty()
                .Length(3, 100)
                .WithMessage("A categoria do produto é obrigatória e deve ter pelo menos 3 caracteres e no máximo 100.");

            RuleFor(p => p.Image)
                .NotEmpty()
                .WithMessage("A URL da imagem do produto é obrigatória.");
        }
    }
}
