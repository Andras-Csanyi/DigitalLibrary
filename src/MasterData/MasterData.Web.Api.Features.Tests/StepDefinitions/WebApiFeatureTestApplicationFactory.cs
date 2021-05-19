namespace DigitalLibrary.MasterData.Web.Api.Features.Tests.StepDefinitions
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    using DigitalLibrary.MasterData.Ctx;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    [ExcludeFromCodeCoverage]
    public class WebApiFeatureTestApplicationFactory<TStartup> : WebApplicationFactory<TStartup>
        where TStartup : class
    {
        public string EntityName { get; set; }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            if (EntityName == null)
            {
                throw new Exception(nameof(EntityName));
            }

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

                services.AddDbContext<MasterDataContext>(options =>
                {
                    options.UseSqlite($"Data Source = {EntityName}");
                });
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
