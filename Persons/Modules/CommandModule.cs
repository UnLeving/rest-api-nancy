using Nancy;
using Nancy.ModelBinding;
using Persons.Interfaces;
using Persons.Models;

namespace Persons.Modules
{
    public class CommandModule : NancyModule
    {
        public CommandModule(ICommandHandler<Person> commandHandler)
        {
            Post["/api/v1/persons"] = parameters =>
            {
                PersonDto personDto;
                try
                {
                    personDto = this.Bind<PersonDto>();
                }
                catch
                {
                    return Negotiate.WithStatusCode(HttpStatusCode.BadRequest);
                }

                Person person = new Person().Create(personDto.Name, personDto.BirthDay);
                if (person == null)
                    return Negotiate.WithStatusCode(HttpStatusCode.UnprocessableEntity);
                commandHandler.Execute(person);
                return Response.AsText("Created").WithHeader("Location",  $"/api/v1/persons/{person.Id}");
            };
        }
    }
}