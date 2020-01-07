namespace WebApp
{
    using System;

    using ControlPanel.QA.DataSample;

    using DigitalLibrary.IaC.ControlPanel.BusinessLogic.Implementations.Menu;
    using DigitalLibrary.IaC.ControlPanel.BusinessLogic.Implementations.Module;
    using DigitalLibrary.IaC.ControlPanel.BusinessLogic.Interfaces.Interfaces;
    using DigitalLibrary.IaC.ControlPanel.Ctx.Context;
    using DigitalLibrary.IaC.ControlPanel.Validators.Validators;
    using DigitalLibrary.IaC.MasterData.BusinessLogic.Implementations.Implementations;
    using DigitalLibrary.IaC.MasterData.BusinessLogic.Interfaces.Interfaces;
    using DigitalLibrary.IaC.MasterData.Ctx.Ctx;
    using DigitalLibrary.IaC.MasterData.Validators.Validators;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    using Newtonsoft.Json;

    public class Startup
    {
        private readonly IWebHostEnvironment _env;

        public IConfiguration Configuration { get; }

        public Startup(
            IConfiguration configuration,
            IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
                })
                .AddApplicationPart(
                    typeof(DigitalLibrary.IaC.ControlPanel.Controllers.Controllers.MenuController).Assembly)
                .AddApplicationPart(
                    typeof(DigitalLibrary.IaC.MasterData.Controllers.Controllers.DimensionController).Assembly)
                .SetCompatibilityVersion(CompatibilityVersion.Latest);

            // if (_env.IsStaging())
            // {
            // services.AddDbContext<TeamManagerContext>(options =>
            // {
            //     options.UseSqlite("Data Source=team_manager_test_db.sqlite");
            // });
            // }

            // services.AddTransient<IPeopleBusinessLogic, PeopleBusinessLogic>();
            // services.AddTransient<ICompanyBusinessLogic, CompanyBusinessLogic>();
            // services.AddTransient<IEventBusinessLogic, EventBusinessLogic>();
            // services.AddTransient<IPositionBusinessLogic, PositionBusinessLogic>();
            // services.AddTransient<ITitleBusinessLogic, TitleBusinessLogic>();
            // services.AddTransient<IPeopleEventLogBusinessLogic, PeopleEventLogBusinessLogic>();
            // services.AddTransient<PeopleValidator>();
            // services.AddTransient<CompanyValidator>();
            // services.AddTransient<EventValidator>();
            // services.AddTransient<PositionValidator>();
            // services.AddTransient<TitleValidator>();
            // services.AddTransient<PeopleEventLogValidator>();

            // if (_env.IsStaging())
            // {
            services.AddDbContext<ControlPanelContext>(options =>
            {
                options.UseSqlite("Data Source=control_panel_test_db.sqlite");
            });
            // }

            services.AddTransient<IMenuBusinessLogic, MenuBusinessLogic>();
            services.AddTransient<MenuValidator>();
            services.AddTransient<IModuleBusinessLogic, ModuleBusinessLogic>();
            services.AddTransient<ModuleValidator>();

            // if (_env.IsStaging())
            // {
            services.AddDbContext<MasterDataContext>(options =>
            {
                options.UseSqlite("Data Source=master_data_test_db.sqlite");
            });
            // }

            services.AddTransient<IMasterDataBusinessLogic, MasterDataBusinessLogic>();
            services.AddTransient<IMasterDataValidators, MasterDataValidators>();
            services.AddTransient<MasterDataDimensionValidator>();
            services.AddTransient<MasterDataDimensionValueValidator>();
            services.AddTransient<DimensionStructureValidator>();

            ServiceProvider serviceProvider = services.BuildServiceProvider();

            if (_env.IsStaging())
            {
                using (IServiceScope scope = serviceProvider.CreateScope())
                {
                    IServiceProvider scopeServices = scope.ServiceProvider;
                    MasterDataContext masterDataContext = scopeServices.GetRequiredService<MasterDataContext>();
                    masterDataContext.Database.EnsureDeleted();
                    masterDataContext.Database.EnsureCreated();
                    MasterDataDataSample.Populate(masterDataContext);

                    ControlPanelContext controlPanelContext = scopeServices.GetRequiredService<ControlPanelContext>();
                    controlPanelContext.Database.EnsureDeleted();
                    controlPanelContext.Database.EnsureCreated();
                    ControlPanelDataSample.Populate(controlPanelContext);

                    // TeamManagerContext teamManagerContext = scopeServices.GetRequiredService<TeamManagerContext>();
                    // teamManagerContext.Database.EnsureDeleted();
                    // teamManagerContext.Database.EnsureCreated();
                }
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}