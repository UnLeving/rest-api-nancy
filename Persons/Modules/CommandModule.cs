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
                Person model = this.BindAndValidate<Person>();
                var validator = ModelValidationResult;
                if (!validator.IsValid)
                    return Negotiate.WithModel(validator).WithStatusCode(HttpStatusCode.UnprocessableEntity);

                commandHandler.Execute(model);
                return Response.AsText("Created").WithHeader("Location", "/api/v1/persons/");
            };
        }
    }
}