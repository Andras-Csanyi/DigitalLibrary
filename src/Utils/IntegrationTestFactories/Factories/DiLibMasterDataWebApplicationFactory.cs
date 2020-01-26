namespace DigitalLibrary.Utils.IntegrationTestFactories.Factories
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    using MasterData.Ctx;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    using Utils;

    [ExcludeFromCodeCoverage]
    public class DiLibMasterDataWebApplicationFactory<TStartup, TTestedEntity> : WebApplicationFactory<TStartup>
        where TStartup : class
        where TTestedEntity : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            string entityName = $"Data Source=master_data.{typeof(TTestedEntity).Name}.db";

            builder.ConfigureServices(services =>
            {
                ServiceDescriptor masterDataDescriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(DbContextOptions<MasterDataContext>));
                if (masterDataDescriptor != null)
                {
                    services.Remove(masterDataDescriptor);
                }

                services.AddDbContext<MasterDataContext>(options => { options.UseSqlite(entityName); });
                ServiceProvider sp = services.BuildServiceProvider();
                using (IServiceScope scope = sp.CreateScope())
                {
                    IServiceProvider scopedServices = scope.ServiceProvider;
                    MasterDataContext db = scopedServices.GetRequiredService<MasterDataContext>();
                    ILogger<DiLibMasterDataWebApplicationFactory<TStartup, TTestedEntity>> logger = scopedServices
                       .GetRequiredService<ILogger<DiLibMasterDataWebApplicationFactory<TStartup, TTestedEntity>>>();

                    db.Database.EnsureDeleted();
                    db.Database.EnsureCreated();
                }
            });
        }
    }
}