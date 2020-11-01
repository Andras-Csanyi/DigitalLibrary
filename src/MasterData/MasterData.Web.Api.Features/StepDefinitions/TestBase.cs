namespace DigitalLibrary.MasterData.Web.Api.Features.StepDefinitions
{
    using System;
    using System.Linq;

    using DigitalLibrary.MasterData.Ctx;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    using Xunit;

    public class TestBase<TStartup> : WebApplicationFactory<TStartup>
        where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            string entityName = $"Data Source=master_data.api.features.db";

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

                    db.Database.EnsureDeleted();
                    db.Database.EnsureCreated();
                }
            });
        }
    }
}