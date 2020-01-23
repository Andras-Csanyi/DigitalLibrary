namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    using Ctx;

    using Interfaces;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;

    using Validators;

    [ExcludeFromCodeCoverage]
    public class TestBase
    {
        public static readonly ILoggerFactory LoggerFactory = Microsoft.Extensions.Logging.LoggerFactory
           .Create(builder => { builder.AddDebug(); });

        protected IMasterDataBusinessLogic masterDataBusinessLogic;

        public TestBase(string TestInfo)
        {
            if (string.IsNullOrEmpty(TestInfo) || string.IsNullOrWhiteSpace(TestInfo))
            {
                throw new ArgumentNullException($"{TestInfo} cannot be null, empty or whitespace!");
            }

            DbContextOptions<MasterDataContext> _dbContextOptions =
                new DbContextOptionsBuilder<MasterDataContext>()
                   .UseSqlite($"Data Source = {TestInfo}.sqlite")
                    // .UseNpgsql("Server=127.0.0.1;Port=5432;Database=dilib;User Id=andrascsanyi;")
                   .UseLoggerFactory(LoggerFactory)
                   .EnableDetailedErrors()
                   .EnableSensitiveDataLogging()
                   .Options;

            DimensionValidator dimensionValidator = new DimensionValidator();
            MasterDataDimensionValueValidator masterDataDimensionValueValidator =
                new MasterDataDimensionValueValidator();
            SourceFormatValidator sourceFormatValidator = new SourceFormatValidator();
            DimensionStructureValidator dimensionStructureValidator = new DimensionStructureValidator();
            MasterDataValidators masterDataValidators = new MasterDataValidators(
                dimensionValidator,
                masterDataDimensionValueValidator,
                sourceFormatValidator,
                dimensionStructureValidator);

            masterDataBusinessLogic = new MasterDataBusinessLogic(
                _dbContextOptions,
                masterDataValidators);

            using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
            {
                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();
            }
        }
    }
}