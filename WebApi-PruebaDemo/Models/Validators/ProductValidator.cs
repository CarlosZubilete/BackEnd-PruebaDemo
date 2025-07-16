using FluentValidation;
using System.Security.Cryptography.X509Certificates;
using WebApi_PruebaDemo.Models.Validators;

namespace WebApi_PruebaDemo.Models.Validators
{
  public class ProductValidator : AbstractValidator<Producto>
  {
    public ProductValidator()
    {
      RuleFor(p => p.Nombre)
        .NotEmpty().WithMessage("The 'Nombre' is required")
        .MaximumLength(100).WithMessage("The 'Nombre' is too long"); ;

      RuleFor(p => p.Precio)
          .GreaterThanOrEqualTo(1).WithMessage("The 'Price' must be taller than 0");

      RuleFor(p => p.Categoria)
          .NotEmpty().WithMessage("The 'Categoria' field is required")
          .MaximumLength(50).WithMessage("The 'Categoria' is too long");

    }
  }
}
