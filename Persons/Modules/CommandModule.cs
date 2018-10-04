using Nancy;
using Nancy.ModelBinding;
using Persons.Abstractions;
using Persons.Interfaces;
using Persons.Models;
using Persons.Repositories;
using Serilog;
using System;

namespace Persons.Modules
{
    public class CommandModule : NancyModule, ICommandHandler
    {
        IPersonRepository repository = new PersonRepository();
        public CommandModule()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File("logs\\myapp.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
            Post["/api/v1/persons"] = parameters => CreatePerson();
        }
        //TODO: return model id if method void Insert(Person item) ??
        public dynamic CreatePerson()
        {
            Log.Debug(DateTime.Now +  " Call command");
            var model = this.Bind<Person>();
            if (model.Calc() == null)
            {
                Log.Debug(DateTime.Now + " returned with UnprocessableEntity");
                return HttpStatusCode.UnprocessableEntity;
            }
            else
            {
                repository.Insert(model);
                Log.Debug(DateTime.Now + " returned with 200OK");
                return Response.AsText("Created").WithHeader("Location", "/api/v1/persons/");
            }
        }
    }
}
