using FluentValidation;
using Models.ModelsDB;

namespace Evoltis_Challenge_Backend.Validations
{
    public class ValidationProduct: AbstractValidator<Product>
    {
        public ValidationProduct()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("El campo {PropertyName} es requerido");
            RuleFor(x => x.Price).NotEmpty().WithMessage("El campo {PropertyName} es requerido");
        }
    }
}
