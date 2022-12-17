using FluentValidation;

namespace Application.Features.Corporates.Commands.CreateCorporate
{
    public class CreateCorporateCommandValidator : AbstractValidator<CreateCorporateCommand>
    {
        public CreateCorporateCommandValidator()
        {
            RuleFor(c => c.CorporateName).NotEmpty();
            RuleFor(c => c.CorporateName).MinimumLength(2);
        }
    }
}
