using DigitalLibrary.ControlPanel.BusinessLogic.Implementations.Menu;
using DigitalLibrary.ControlPanel.BusinessLogic.Implementations.Module;
using DigitalLibrary.ControlPanel.BusinessLogic.Interfaces.Interfaces;
using DigitalLibrary.MasterData.BusinessLogic.Implementations.Implementations;
using DigitalLibrary.MasterData.BusinessLogic.Interfaces.Interfaces;
using DigitalLibrary.MasterData.Controllers.Controllers;
using DigitalLibrary.MasterData.Ctx.Ctx;
using DigitalLibrary.MasterData.Validators.Validators;
using DigitalLibrary.Utils.ControlPanel.DataSample;

namespace WebApp
{
    using System;

    using DigitalLibrary.ControlPanel.Controllers;
    using DigitalLibrary.ControlPanel.Ctx;
    using DigitalLibrary.ControlPanel.Ctx.Ctx;
    using DigitalLibrary.ControlPanel.Validators;

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
                    typeof(MenuController).Assembly)
               .AddApplicationPart(
                    typeof(DimensionController).Assembly)
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
                options.EnableSensitiveDataLogging();
            });
            // }

            services.AddTransient<IMasterDataBusinessLogic, MasterDataBusinessLogic>();
            services.AddTransient<IMasterDataValidators, MasterDataValidators>();
            services.AddTransient<MasterDataDimensionValidator>();
            services.AddTransient<MasterDataDimensionValueValidator>();
            services.AddTransient<TopDimensionStructureValidator>();
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