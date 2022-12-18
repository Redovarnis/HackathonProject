using FluentValidation;

namespace Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductValidator()
        {
            RuleFor(u => u.ProductName).NotEmpty().NotNull().WithMessage("Product Name must not be empty");
            RuleFor(u => u.CorporateName).NotEmpty().NotNull().WithMessage("Corporate Name must not be empty");
            RuleFor(u => u.Id).GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }
}
