namespace DigitalLibrary.IaC.TeamManager.Integration.Tests.Factories
{
    using System;
    using System.Linq;

    using Ctx.Context;

    using MasterData.Ctx.Ctx;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    using Utils;

    public class DiLibTeamManagerWebApplicationFactory<TStartup, TTestedEntity> : WebApplicationFactory<TStartup>
        where TStartup : class
        where TTestedEntity : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            string entityName = $"Data Source=teammanager.{typeof(TTestedEntity).Name}.db";

            builder.ConfigureServices(services =>
            {
                ServiceDescriptor masterDataDescriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(DbContextOptions<MasterDataContext>));
                if (masterDataDescriptor != null)
                {
                    services.Remove(masterDataDescriptor);
                }

                ServiceDescriptor teamManagerDescriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(DbContextOptions<TeamManagerContext>));
                if (teamManagerDescriptor != null)
                {
                    services.Remove(teamManagerDescriptor);
                }

                services.AddDbContext<TeamManagerContext>(options => { options.UseSqlite(entityName); });


                ServiceProvider sp = services.BuildServiceProvider();

                using (IServiceScope scope = sp.CreateScope())
                {
                    IServiceProvider scopedServices = scope.ServiceProvider;
                    TeamManagerContext db = scopedServices.GetRequiredService<TeamManagerContext>();
                    ILogger<DiLibTeamManagerWebApplicationFactory<TStartup, TTestedEntity>> logger = scopedServices
                        .GetRequiredService<ILogger<DiLibTeamManagerWebApplicationFactory<TStartup, TTestedEntity>>>();

                    db.Database.EnsureDeleted();
                    db.Database.EnsureCreated();

                    TeamManagerSeed.Seed(db);
                }
            });
        }
    }
}