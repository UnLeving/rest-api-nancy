using AutoMapper;
using FluentValidation;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;
using Persons.Handlers;
using Persons.Interfaces;
using Persons.Models;
using Serilog;
namespace Persons.Service
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            Mapper.Initialize(config => config.CreateMap<Person, PersonDto>());
            Log.Logger = new LoggerConfiguration()
              .Enrich.FromLogContext()
              .MinimumLevel.Verbose()
              .WriteTo.File("logs\\myapp.txt", rollingInterval: RollingInterval.Day)
              .CreateLogger();
        }
         
        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            container.Register<ICommandHandler<Person>, PersonCommandHandler>();
            container.Register<IQueryHandler<int, Person>, PersonQueryHandler>();            
        }
    }
}