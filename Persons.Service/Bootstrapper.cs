using FluentValidation;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;
using Persons.Handlers;
using Persons.Helpers;
using Persons.Interfaces;
using Persons.Models;

namespace Persons.Service
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            AutoMapperConfig.Configure();
        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            container.Register<ICommandHandler<Person>, PersonCommandHandler>();
            container.Register<IQueryHandler<int, Person>, PersonQueryHandler>();
            container.Register<AbstractValidator<Person>, PersonPropValidation>();
        }
    }
}