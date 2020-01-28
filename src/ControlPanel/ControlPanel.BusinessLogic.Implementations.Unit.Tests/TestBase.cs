namespace DigitalLibrary.ControlPanel.BusinessLogic.Implementations.Unit.Tests
{
    using Ctx.Ctx;

    using Implementations.Menu;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;

    using Module;

    using Utils.Guards;

    using Validators;

    public class TestBase
    {
        public static readonly ILoggerFactory LoggerFactory = Microsoft.Extensions.Logging.LoggerFactory
           .Create(builder => { builder.AddDebug(); });

        protected MenuBusinessLogic MenuBusinessLogic;

        protected ModuleBusinessLogic ModuleBusinessLogic;

        public TestBase(string TestInfo)
        {
            string msg = $"{nameof(TestInfo)} cannot be empty.";
            Check.NotNullOrEmptyOrWhitespace(TestInfo);

            string fileName = $"Data Source={TestInfo}.sqlite";

            MenuValidator menuValidator = new MenuValidator();
            ModuleValidator moduleValidator = new ModuleValidator();

            DbContextOptions<ControlPanelContext> dbContext = new DbContextOptionsBuilder<ControlPanelContext>()
               .UseSqlite(fileName)
               .UseLoggerFactory(LoggerFactory)
               .EnableDetailedErrors()
               .EnableSensitiveDataLogging()
               .Options;

            MenuBusinessLogic = new MenuBusinessLogic(menuValidator, dbContext);
            ModuleBusinessLogic = new ModuleBusinessLogic(MenuBusinessLogic, moduleValidator, dbContext);

            using (ControlPanelContext ctx = new ControlPanelContext(dbContext))
            {
                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();
            }
        }
    }
}