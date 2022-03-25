﻿using VrcOscIntegrations.Services;

namespace VrcOscIntegrations
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHostedService<OscActions>();
            services.AddRazorPages();

            IntegrationsManager.Manager.RegisterIntegrations(ref services);
        }

        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            app.UseRouting();

            app.UseEndpoints(ends =>
            {
                ends.MapControllers();
            });

            IntegrationsManager.Manager.EnableIntegrations();
        }
    }
}