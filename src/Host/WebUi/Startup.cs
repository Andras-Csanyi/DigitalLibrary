namespace DigitalLibrary.Ui.WebUi
{
    using System;

    using BlazorStrap;

    using Components.SourceFormatBuilder;

    using ControlPanel.WebApi.Client.Menu;

    using MasterData.Validators;
    using MasterData.WebApi.Client;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    using Notifiers;

    using Services;

    using Utils.DiLibHttpClient;

    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddBootstrapCSS();
            services.AddHttpClient<IControlPanelWebClient, ControlPanelWebClient>(config =>
            {
                config.BaseAddress = new Uri("http://localhost:5000");
            });
            // services.AddHttpClient<IMasterDataHttpClient, MasterDataHttpClient>(config =>
            // {
            //     config.BaseAddress = new Uri("http://localhost:5000");
            // });
            services.AddHttpClient("httpClient", config => { config.BaseAddress = new Uri("http://localhost:5000"); });
            services.AddHttpClient<IDiLibHttpClient, DiLibHttpClient>(config =>
            {
                config.BaseAddress = new Uri("http://localhost:5000");
            });
            services.AddTransient<IMasterDataHttpClient, MasterDataHttpClient>();

            // Services
            services.AddSingleton<SourceFormatBuilderService>();
            services.AddSingleton<ISourceFormatSelectorComponentService,
                SourceFormatSelectorComponentComponentService>();
            services.AddSingleton<IDimensionStructureDisplayComponentService,
                DimensionStructureDisplayComponentComponentService>();
            services.AddSingleton<IDimensionStructureTreeComponentService, DimensionStructureTreeComponentService>();

            // Notifiers
            services.AddSingleton<DocumentBuilderDocumentDisplayNotifier>();

            // validators
            services.AddTransient<DimensionStructureValidator>();
            services.AddTransient<DimensionValidator>();
            services.AddTransient<MasterDataDimensionValueValidator>();
            services.AddTransient<SourceFormatValidator>();
            services.AddTransient<IMasterDataValidators, MasterDataValidators>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios,
                // see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}