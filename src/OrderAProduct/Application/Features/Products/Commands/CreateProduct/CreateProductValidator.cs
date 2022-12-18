using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductValidator()
        {
            RuleFor(c => c.ProductName).NotEmpty().NotNull();
            RuleFor(p => p.CorporateName).NotEmpty().NotNull();
        }
    }
}
