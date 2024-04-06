using Domain.Entities;
using FluentValidation;

namespace Application.Common.Validators
{
    public class MovieValidator : AbstractValidator<Movie>
    {
        public MovieValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Title bosh bolmasligi kerak")
                .Length(3, 40)
                .WithMessage("Title 3 va 40 belgi orasida bolishi kerak");

            RuleFor(x => x.Year)
                .ExclusiveBetween(1970, DateTime.UtcNow.Year)
                .WithMessage($"Year 1970 va {DateTime.UtcNow.Year} yil orasida bolishi kerak");

            RuleFor(x => x.Director)
                .NotEmpty()
                .WithMessage("Direktor bosh bolmasligi kerak")
                .Length(3, 40)
                .WithMessage("Direktor nomi 3 va 40 belgi orasida bolishi kerak");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Description bosh bolmasligi kerak")
                .MinimumLength(10)
                .WithMessage("Kamida 10ta belgi bolishi kerak");

            RuleFor(x => x.Company)
                .NotEmpty()
                .WithMessage("Company bosh bolmasligi kerak")
                .Length(5, 30)
                .WithMessage("Company 5 va 30 belgi orasida boloshi kerak");

            RuleFor(x => x.Country)
                .NotEmpty()
                .WithMessage("Country bosh bolmasligi kerak")
                .Length(2, 30)
                .WithMessage("Country 2 va 30 belgi orasida boloshi kerak");

            RuleFor(x => x.GenreId)
                .GreaterThan(0)
                .WithMessage("GenreId 0 bomasligi kerak");
        }
    }
}
