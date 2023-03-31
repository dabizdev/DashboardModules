using Dashboard.Common.Interfaces;
using Dashboard.Common.Modules;
using Dashboard.Common.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Dashboard.Modules.RHRP
{
    [DashboardModule(Name = "Error Type Module", Lob = "RHRP")]
    public class Tenant : ITenant
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<Tenant> _logger;
        private readonly IServiceProvider _provider;
        public string Name => typeof(Tenant).Namespace;

        public Tenant(ILogger<Tenant> logger, IConfiguration config)
        {
            _configuration = config;
            _logger = logger;

            _provider = BuildServices();
        }

        private IServiceProvider BuildServices()
        {
            var services = new ServiceCollection();

            services.AddLogging();

            services.Scan(scan => scan.FromCallingAssembly()
                .AddClasses(c => c.AssignableTo<IErrorTypeModule>(), publicOnly: true)
                .AsImplementedInterfaces()
                .WithTransientLifetime());


            return services.BuildServiceProvider();
        }

        public IErrorTypeModule GetErrorTypeProcessor()
        {
            var handler = _provider.GetService<IErrorTypeModule>();
            return handler;
        }
    }
}
