namespace MasterData.BusinessLogic.Tests.Integration
{
    using System;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;

    using DigitalLibrary.MasterData.BusinessLogic.Implementations;
    using DigitalLibrary.MasterData.BusinessLogic.Implementations.Dimension;
    using DigitalLibrary.MasterData.BusinessLogic.Implementations.DimensionStructure;
    using DigitalLibrary.MasterData.BusinessLogic.Implementations.DimensionStructureNode;
    using DigitalLibrary.MasterData.BusinessLogic.Implementations.DimensionValue;
    using DigitalLibrary.MasterData.BusinessLogic.Implementations.SourceFormat;
    using DigitalLibrary.MasterData.BusinessLogic.Interfaces;
    using DigitalLibrary.MasterData.Ctx;
    using DigitalLibrary.MasterData.Validators;

    using Microsoft.EntityFrameworkCore;

    using Xunit.Abstractions;

    [ExcludeFromCodeCoverage]
    public class TestBase
    {
        protected readonly IMasterDataBusinessLogic _masterDataBusinessLogic;

        protected readonly ITestOutputHelper _testOutputHelper;

        public TestBase(
            ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;

            Random rnd = new Random();
            string path = Directory.GetCurrentDirectory();
            string fileName = $"sqlite_{rnd.Next(1, 10000000)}.sqlite";
            string sqlLiteFileNameWithPath = $"{path}/{fileName}";
            _testOutputHelper.WriteLine($"SQLite file name: {sqlLiteFileNameWithPath}");

            DbContextOptions<MasterDataContext> _dbContextOptions = new DbContextOptionsBuilder<MasterDataContext>()
               .UseSqlite($"Data Source = {sqlLiteFileNameWithPath}")
               .LogTo(msg => Debug.WriteLine(msg))
               .EnableDetailedErrors()
               .EnableSensitiveDataLogging()
               .Options;

            DimensionValidator dimensionValidator = new();
            MasterDataDimensionValueValidator masterDataDimensionValueValidator = new();
            SourceFormatValidator sourceFormatValidator = new();
            DimensionStructureValidator dimensionStructureValidator = new();
            DimensionStructureDimensionStructureValidator dimensionStructureDimensionStructureValidator = new();
            DimensionStructureQueryObjectValidator dimensionStructureQueryObjectValidator = new();
            DimensionStructureNodeValidator dimensionStructureNodeValidator = new();
            SourceFormatDimensionStructureNodeValidator sourceFormatDimensionStructureNodeValidator = new();

            MasterDataValidators masterDataValidators = new(
                dimensionValidator,
                masterDataDimensionValueValidator,
                sourceFormatValidator,
                dimensionStructureValidator,
                dimensionStructureDimensionStructureValidator,
                dimensionStructureQueryObjectValidator,
                dimensionStructureNodeValidator,
                sourceFormatDimensionStructureNodeValidator);

            IMasterDataDimensionBusinessLogic masterDataDimensionBusinessLogic = new MasterDataDimensionBusinessLogic(
                _dbContextOptions, masterDataValidators);
            IMasterDataDimensionStructureBusinessLogic masterDataDimensionStructureBusinessLogic =
                new MasterDataDimensionStructureBusinessLogic(_dbContextOptions, masterDataValidators);
            IMasterDataDimensionValueBusinessLogic masterDataDimensionValueBusinessLogic =
                new MasterDataDimensionValueBusinessLogic(_dbContextOptions, masterDataValidators);
            IMasterDataSourceFormatBusinessLogic masterDataSourceFormatBusinessLogic =
                new MasterDataSourceFormatBusinessLogic(_dbContextOptions, masterDataValidators);
            IMasterDataDimensionStructureNodeBusinessLogic masterDataDimensionStructureNodeBusinessLogic =
                new MasterDataDimensionStructureNodeBusinessLogic(_dbContextOptions, masterDataValidators);

            _masterDataBusinessLogic = new MasterDataBusinessLogic(
                masterDataDimensionBusinessLogic,
                masterDataDimensionStructureBusinessLogic,
                masterDataDimensionValueBusinessLogic,
                masterDataSourceFormatBusinessLogic,
                masterDataDimensionStructureNodeBusinessLogic);

            using (MasterDataContext ctx = new(_dbContextOptions))
            {
                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();
                // MasterDataDataSample.Populate(ctx);
            }
        }
    }
}