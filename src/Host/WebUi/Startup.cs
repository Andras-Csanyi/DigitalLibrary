// <copyright file="Startup.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

using IMasterDataHttpClient = DigitalLibrary.MasterData.Web.Api.Client.Interfaces.IMasterDataHttpClient;

namespace DigitalLibrary.Ui.WebUi
{
    using System;

    using BlazorStrap;

    using DigitalLibrary.ControlPanel.WebApi.Client.Menu;
    using DigitalLibrary.MasterData.Validators;
    using DigitalLibrary.MasterData.WebApi.Client;
    using DigitalLibrary.Ui.WebUi.Components.SourceFormatBuilder;
    using DigitalLibrary.Ui.WebUi.Notifiers;
    using DigitalLibrary.Ui.WebUi.Services;
    using DigitalLibrary.Utils.DiLibHttpClient;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
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
            services.AddSingleton<IDimensionStructureTreeComponentService, DimensionStructureTreeComponentService>();
            services.AddSingleton<ISourceFormatBuilderService, SourceFormatBuilderService>();
            services.AddSingleton<IDimensionDomainEntityHelperService, DimensionDomainEntityHelperService>();
            services.AddSingleton<IDomainEntityHelperService, DomainEntityHelperService>();

            // Notifiers
            services.AddSingleton<DocumentBuilderDocumentDisplayNotifier>();
            services.AddSingleton<SourceFormatBuilderNotifierService>();

            // validators
            services.AddTransient<DimensionStructureValidator>();
            services.AddTransient<DimensionValidator>();
            services.AddTransient<MasterDataDimensionValueValidator>();
            services.AddTransient<SourceFormatValidator>();
            services.AddTransient<IMasterDataValidators, MasterDataValidators>();
            services.AddTransient<DimensionStructureDimensionStructureValidator>();
            services.AddTransient<DimensionStructureQueryObjectValidator>();
        }
    }
}