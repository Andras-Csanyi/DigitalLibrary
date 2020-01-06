namespace DigitalLibrary.IaC.ControlPanel.BusinessLogic.Implementations.Tests.Tests
{
    using Ctx.Context;

    using Implementations.Menu;

    using Microsoft.EntityFrameworkCore;

    using Module;

    using Validators.Validators;

    public class TestBase
    {
        protected MenuBusinessLogic MenuBusinessLogic;

        protected ModuleBusinessLogic ModuleBusinessLogic;

        public TestBase()
        {
            string fileName = "Data Source=test.db";

            MenuValidator menuValidator = new MenuValidator();
            ModuleValidator moduleValidator = new ModuleValidator();

            DbContextOptions<ControlPanelContext> dbContext = new DbContextOptionsBuilder<ControlPanelContext>()
                .UseSqlite(fileName)
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