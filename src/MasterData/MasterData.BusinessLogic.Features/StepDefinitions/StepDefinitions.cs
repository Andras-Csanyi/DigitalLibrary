// <copyright file="SourceFormatFeature.Background.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

[assembly: Xunit.CollectionBehavior(DisableTestParallelization = true)]

namespace DigitalLibrary.MasterData.BusinessLogic.Features.StepDefinitions
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    using DigitalLibrary.MasterData.BusinessLogic.Implementations;
    using DigitalLibrary.MasterData.BusinessLogic.Implementations.Dimension;
    using DigitalLibrary.MasterData.BusinessLogic.Implementations.DimensionStructure;
    using DigitalLibrary.MasterData.BusinessLogic.Implementations.DimensionStructureNode;
    using DigitalLibrary.MasterData.BusinessLogic.Implementations.DimensionValue;
    using DigitalLibrary.MasterData.BusinessLogic.Implementations.SourceFormat;
    using DigitalLibrary.MasterData.BusinessLogic.Interfaces;
    using DigitalLibrary.MasterData.Ctx;
    using DigitalLibrary.MasterData.Validators;
    using DigitalLibrary.Utils.Guards;
    using DigitalLibrary.Utils.IntegrationTestFactories.Providers;
    using DigitalLibrary.Utils.MasterDataTestHelper;
    using DigitalLibrary.Utils.MasterDataTestHelper.Tools;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    using TechTalk.SpecFlow;

    using Xunit.Abstractions;

    /// <summary>
    ///     Background steps for <see cref="SourceFormat" /> related test cases.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "CA1707", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    [Binding]
    public partial class StepDefinitions : IDisposable
    {
        private readonly ITestOutputHelper _outputHelper;

        private readonly string _testInfo = nameof(StepDefinitions);

        private DbContextOptions<MasterDataContext> _dbContextOptions;

        protected IMasterDataBusinessLogic _masterDataBusinessLogic;

        protected IMasterDataTestHelper _masterDataTestHelper;

        protected ScenarioContext _scenarioContext;

        private IServiceProvider _serviceProvider;

        protected IStringHelper stringHelper;

        protected const string SUCCESS = "SUCCESS";

        protected StepDefinitions(
            ITestOutputHelper testOutputHelper,
            ScenarioContext scenarioContext)
        {
            Check.IsNotNull(testOutputHelper);
            Check.IsNotNull(scenarioContext);

            _scenarioContext = scenarioContext;
            stringHelper = new StringHelper();
            _outputHelper = testOutputHelper;
        }

        public void Dispose()
        {
            // _masterDataBusinessLogic.Dispose();
            (_serviceProvider as IDisposable)?.Dispose();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _serviceProvider = new ServiceCollection()
               .AddLogging(x => x.AddProvider(new TestLoggerProvider(_outputHelper)))
               .AddEntityFrameworkSqlite()
               .BuildServiceProvider();

            _dbContextOptions = new DbContextOptionsBuilder<MasterDataContext>()
               .UseSqlite($"Data Source = {_testInfo}.sqlite")

                // .UseNpgsql("Server=127.0.0.1;Port=5432;Database=dilib;User Id=andrascsanyi;")
                // .UseLoggerFactory(MasterDataLogger)
                // .UseInternalServiceProvider(_serviceProvider)
                // .EnableDetailedErrors()
                // .EnableSensitiveDataLogging()
               .Options;

            DimensionValidator dimensionValidator = new DimensionValidator();
            MasterDataDimensionValueValidator masterDataDimensionValueValidator =
                new MasterDataDimensionValueValidator();
            SourceFormatValidator sourceFormatValidator = new SourceFormatValidator();
            DimensionStructureValidator dimensionStructureValidator = new DimensionStructureValidator();
            DimensionStructureDimensionStructureValidator dimensionStructureDimensionStructureValidator =
                new DimensionStructureDimensionStructureValidator();
            DimensionStructureQueryObjectValidator dimensionStructureQueryObjectValidator =
                new DimensionStructureQueryObjectValidator();
            DimensionStructureNodeValidator dimensionStructureNodeValidator = new DimensionStructureNodeValidator();

            MasterDataValidators masterDataValidators = new MasterDataValidators(
                dimensionValidator,
                masterDataDimensionValueValidator,
                sourceFormatValidator,
                dimensionStructureValidator,
                dimensionStructureDimensionStructureValidator,
                dimensionStructureQueryObjectValidator,
                dimensionStructureNodeValidator);

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

            using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
            {
                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();
                // MasterDataDataSample.Populate(ctx);
            }

            ISourceFormatFactory sourceFormatFactory = new SourceFormatFactory(stringHelper);
            IDimensionStructureFactory dimensionStructureFactory = new DimensionStructureFactory(stringHelper);
            _masterDataTestHelper = new MasterDataTestHelper(
                sourceFormatFactory,
                dimensionStructureFactory);
        }
    }
}