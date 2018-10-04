using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;
using Persons.Helpers;

namespace Persons.Service
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            AutoMapperConfig.Configure();
        }
    }
}
