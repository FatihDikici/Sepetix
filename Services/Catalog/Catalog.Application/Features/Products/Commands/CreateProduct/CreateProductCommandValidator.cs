using FluentValidation;

namespace Catalog.Application.Features.Products.Commands.CreateProduct;

public sealed class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty()
            .MaximumLength(150);

        RuleFor(command => command.Description)
            .NotEmpty()
            .MaximumLength(1000);

        RuleFor(command => command.Price)
            .GreaterThan(0);

        RuleFor(command => command.Stock)
            .GreaterThanOrEqualTo(0);

        RuleFor(command => command.CategoryId)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(command => command.ImageUrl)
            .NotEmpty()
            .MaximumLength(500);
    }
}
