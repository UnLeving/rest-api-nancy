using Topshelf;
using Topshelf.Nancy;

namespace Persons.Service
{
    internal static class ConfigureService
    {
        internal static void Configure()
        {
            HostFactory.Run(configure =>
            {
                configure.Service<Service>(service =>
                {
                    service.ConstructUsing(s => new Service());
                    service.WhenStarted(s => s.Start());
                    service.WhenStopped(s => s.Stop());
                    service.WithNancyEndpoint(configure, c =>
                    {
                        c.AddHost(port: 1234);
                        c.CreateUrlReservationsOnInstall();
                    });
                });

                //configure.RunAsLocalSystem();
                configure.RunAsNetworkService();
                configure.SetServiceName("RESTTopshelf");
                configure.SetDisplayName("RESTTopshelf");
            });
        }
    }
}