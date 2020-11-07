namespace DigitalLibrary.MasterData.Web.Api.Features.StepDefinitions
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    using DigitalLibrary.MasterData.Ctx;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    using Xunit;

    [ExcludeFromCodeCoverage]
    public class WebApiFeatureTestApplicationFactory<TStartup> : WebApplicationFactory<TStartup>
        where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            string entityName = $"Data Source=master_data.api.features.db";

            builder.ConfigureServices(services =>
            {
                ServiceDescriptor masterDataContextDescriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(DbContextOptions<MasterDataContext>));

                services.Remove(masterDataContextDescriptor);

                ServiceDescriptor found = services.SingleOrDefault(d => d.ServiceType == typeof
                    (DbContextOptions<MasterDataContext>));
                if (found != null)
                {
                    throw new Exception();
                }

                services.AddDbContext<MasterDataContext>(options => { options.UseSqlite(entityName); });
                ServiceProvider sp = services.BuildServiceProvider();
                using (IServiceScope scope = sp.CreateScope())
                {
                    IServiceProvider scopedServices = scope.ServiceProvider;
                    MasterDataContext db = scopedServices.GetRequiredService<MasterDataContext>();

                    db.Database.EnsureDeleted();
                    db.Database.EnsureCreated();
                }
            });
        }
    }
}