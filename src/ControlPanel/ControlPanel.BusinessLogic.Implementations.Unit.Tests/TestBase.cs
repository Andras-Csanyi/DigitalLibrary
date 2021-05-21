// <copyright file="TestBase.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.ControlPanel.BusinessLogic.Implementations.Unit.Tests
{
    using System.Diagnostics.CodeAnalysis;

    using DigitalLibrary.ControlPanel.BusinessLogic.Implementations.Menu;
    using DigitalLibrary.ControlPanel.BusinessLogic.Implementations.Module;
    using DigitalLibrary.ControlPanel.Ctx.Ctx;
    using DigitalLibrary.ControlPanel.Validators;
    using DigitalLibrary.Utils.Guards;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;

    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    public class TestBase
    {
        public static readonly ILoggerFactory LoggerFactory = Microsoft.Extensions.Logging.LoggerFactory
           .Create(builder => { builder.AddDebug(); });

        [SuppressMessage("ReSharper", "SA1401", Justification = "tmp")]
        protected readonly MenuBusinessLogic MenuBusinessLogic;

        [SuppressMessage("ReSharper", "SA1401", Justification = "tmp")]
        protected readonly ModuleBusinessLogic ModuleBusinessLogic;

        public TestBase(string testInfo)
        {
            string msg = $"{nameof(testInfo)} cannot be empty.";
            Check.NotNullOrEmptyOrWhitespace(testInfo, msg);

            string fileName = $"Data Source={testInfo}.sqlite";

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
