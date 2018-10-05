using Nancy;
using Nancy.ModelBinding;
using Persons.Handlers;
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
                Person model = this.Bind<Person>();
                if (model.Calc() == null)
                {
                    Log.Debug(DateTime.Now + " returned with UnprocessableEntity");
                    return HttpStatusCode.UnprocessableEntity;
                }
                else
                {
                    commandHandler.Execute(model);
                    Log.Debug(DateTime.Now + " returned with 200OK");
                    return Response.AsText("Created").WithHeader("Location", "/api/v1/persons/");
                }
            };
        }
    }
}