namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Implementations.Tests.Tests
{
    using System.Reflection;

    using Ctx.Context;

    using Implementations.Company;
    using Implementations.Event;

    using Interfaces.Interfaces;

    using Microsoft.EntityFrameworkCore;

    using Validators.Validators;

    using Xunit;

    [Collection(nameof(AssemblyName.GetAssemblyName))]
    public class TestBase
    {
        protected readonly ICompanyBusinessLogic CompanyBusinessLogic;

        protected readonly IEventBusinessLogic EventBusinessLogic;

        protected TestBase()
        {
            string fileName = $"Data Source=test.db";

            CompanyValidator companyValidator = new CompanyValidator();
            DbContextOptions<TeamManagerContext> options = new DbContextOptionsBuilder<TeamManagerContext>()
                .UseSqlite(fileName)
                .Options;

            EventValidator eventValidator = new EventValidator();

            CompanyBusinessLogic = new CompanyBusinessLogic(options, companyValidator);
            EventBusinessLogic = new EventBusinessLogic(options, eventValidator);

            using (TeamManagerContext ctx = new TeamManagerContext(options))
            {
                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();
            }
        }
    }
}