using DigitalLibrary.ControlPanel.BusinessLogic.Implementations.Menu;
using DigitalLibrary.ControlPanel.BusinessLogic.Implementations.Module;

using Microsoft.EntityFrameworkCore;

namespace DigitalLibrary.ControlPanel.BusinessLogic.Implementations.Tests.Tests
{
    using Ctx;
    using Ctx.Ctx;

    using Validators;

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