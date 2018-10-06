using Nancy;
using Nancy.ModelBinding;
using Persons.Interfaces;
using Persons.Models;
using Serilog;
using System;

namespace Persons.Modules
{
    public class CommandModule : NancyModule
    {
        public CommandModule(ICommandHandler<Person> commandHandler)
        {
            Log.Logger = new LoggerConfiguration().WriteTo.File("logs\\myapp.txt", rollingInterval: RollingInterval.Day).CreateLogger();
            Post["/api/v1/persons"] = parameters =>
            {
                Person model = this.BindAndValidate<Person>();
                var validator = ModelValidationResult;
                if (!validator.IsValid)
                    return Negotiate.WithModel(validator).WithStatusCode(HttpStatusCode.UnprocessableEntity);

                commandHandler.Execute(model);
                Log.Debug(DateTime.Now + " returned with 200OK");
                return Response.AsText("Created").WithHeader("Location", "/api/v1/persons/");
            };
        }
    }
}