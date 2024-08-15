using WebApi.Application.Commands;
using FluentValidation;

namespace WebApi.Application.Validators;

public class AddProductCommandValidator : AbstractValidator<AddProductCommand>
{
    public AddProductCommandValidator()
    {
        RuleFor(p => p.Product.Name)
            .NotEmpty()
            .WithMessage("El nombre del producto no puede ser nulo");

        RuleFor(p => p.Product.Name)
            .MaximumLength(50)
            .WithMessage("El nombre no debe ser mayor a 50 carácteres");
    }
}
