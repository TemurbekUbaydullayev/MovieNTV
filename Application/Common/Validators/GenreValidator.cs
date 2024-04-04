

using Domain.Entities;
using FluentValidation;

namespace Application.Common.Validators
{
    public class GenreValidator : AbstractValidator<Genre>
    {
        public GenreValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name bolmasligi lozim")
                .Length(3, 50)
                .WithMessage("Name 3 va 50 orasida bolishi kerak");
            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Description bosh bolmasligi lozim")
                .Length(3, 50)
                .WithMessage("Description  3 va 50 orasida bolishi kerak");
        }
    }
}
