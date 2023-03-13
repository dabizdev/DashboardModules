using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dashboard.Common.Interfaces;
using Dashboard.Common.DataModels;
using Dashboard.Common.Modules;
using Dashboard.Common.Options;
using Dashboard.Common.Delegates;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Dashboard.Modules.RHRP
{
    [DashboardModule(Name = "Error Type Module", Lob = "RHRP")]
    public class Tenant : ITenant
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<Tenant> _logger;
        private readonly IServiceProvider _provider;
        private readonly BusinessServiceOptions _options;
        public string Name => typeof(Tenant).Namespace;

        public Tenant(ILogger<Tenant> logger, IConfiguration config)
        {
            _configuration = config;
            _logger = logger;

            _options = new BusinessServiceOptions();

            //TODO:Fix this to get data from config
            //_configuration.GetSection(BusinessServiceOptions.Client).Bind(_options);

            _provider = BuildServices();
        }

        private IServiceProvider BuildServices()
        {
            var services = new ServiceCollection();

            //services.AddDbContext<CommercialDbContext>(options =>
            //    options.UseSqlServer(_configuration.GetConnectionString(_configuration.GetValue<string>("ClientSettings:Organization"))));

            services.AddLogging();

            //services.AddScoped<ILayout, LayoutManager>();

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
