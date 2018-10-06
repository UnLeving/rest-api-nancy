using FluentValidation;
using Persons.Models;

namespace Persons.Helpers
{
    public class PersonPropValidation : AbstractValidator<Person>
    {
        public PersonPropValidation()
        {
            RuleFor(request => request.Name).NotEmpty().WithMessage("You must specify a username");
            RuleFor(request => request.Age).GreaterThan(120).WithMessage("Too old");
        }
    }
}