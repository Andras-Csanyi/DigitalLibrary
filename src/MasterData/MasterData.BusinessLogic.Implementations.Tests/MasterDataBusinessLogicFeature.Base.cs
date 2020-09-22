// <copyright file="SourceFormatFeature.Background.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.Interfaces;
    using DigitalLibrary.MasterData.Ctx;
    using DigitalLibrary.MasterData.Validators;
    using DigitalLibrary.Utils.ControlPanel.DataSample.MasterData;
    using DigitalLibrary.Utils.Guards;
    using DigitalLibrary.Utils.IntegrationTestFactories.Providers;
    using DigitalLibrary.Utils.MasterDataTestHelper;
    using DigitalLibrary.Utils.MasterDataTestHelper.Tools;
    using DigitalLibrary.Utils.MasterDataTestHelper.Tools.DimensionStructureLinkedListHelper;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Console;
    using Microsoft.Extensions.Options;

    using TechTalk.SpecFlow;

    using Xunit.Abstractions;

    /// <summary>
    /// Background steps for <see cref="SourceFormat"/> related test cases.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "CA1707", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    public class MasterDataBusinessLogicFeature : IDisposable
    {
        protected IMasterDataBusinessLogic _masterDataBusinessLogic;

        private readonly string _testInfo;

        private readonly ITestOutputHelper _outputHelper;

        private readonly IServiceProvider _serviceProvider;

        private DbContextOptions<MasterDataContext> _dbContextOptions;

        protected Dictionary<string, DomainModel.SourceFormat> _sourceFormatBag =
            new Dictionary<string, DomainModel.SourceFormat>();

        protected Dictionary<string, DomainModel.SourceFormat> _sourceFormatSaveOperationResultBag =
            new Dictionary<string, DomainModel.SourceFormat>();

        protected Dictionary<string, DomainModel.DimensionStructure> _dimensionStructureBag =
            new Dictionary<string, DomainModel.DimensionStructure>();

        protected Dictionary<string, DomainModel.DimensionStructure> _dimensionStructureStoredObjectsBag =
            new Dictionary<string, DomainModel.DimensionStructure>();

        protected IMasterDataTestHelper _masterDataTestHelper;


        protected MasterDataBusinessLogicFeature(
            string testInfo,
            ITestOutputHelper testOutputHelper)
        {
            _testInfo = testInfo
             ?? throw new ArgumentNullException($"No {nameof(testInfo)} is provided");
            _outputHelper = testOutputHelper
             ?? throw new ArgumentNullException($"No {nameof(testOutputHelper)} provided");

            _serviceProvider = new ServiceCollection()
               .AddLogging(x => x.AddProvider(new TestLoggerProvider(_outputHelper)))
               .AddEntityFrameworkSqlite()
               .BuildServiceProvider();
        }

        [BeforeScenario]
        public void Background()
        {
            Check.NotNullOrEmptyOrWhitespace(_testInfo);

            _dbContextOptions = new DbContextOptionsBuilder<MasterDataContext>()
               .UseSqlite($"Data Source = {_testInfo}.sqlite")

                // .UseNpgsql("Server=127.0.0.1;Port=5432;Database=dilib;User Id=andrascsanyi;")
                // .UseLoggerFactory(MasterDataLogger)
                // .UseInternalServiceProvider(_serviceProvider)
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

            MasterDataValidators masterDataValidators = new MasterDataValidators(
                dimensionValidator,
                masterDataDimensionValueValidator,
                sourceFormatValidator,
                dimensionStructureValidator,
                dimensionStructureDimensionStructureValidator,
                dimensionStructureQueryObjectValidator);

            IStringHelper stringHelper = new StringHelper();
            ISourceFormatFactory sourceFormatFactory = new SourceFormatFactory(stringHelper);
            IDimensionStructureFactory dimensionStructureFactory = new DimensionStructureFactory(stringHelper);
            IDimensionStructureLinkedListHelper dimensionStructureLinkedListHelper =
                new DimensionStructureLinkedListHelper();
            _masterDataTestHelper = new MasterDataTestHelper(
                sourceFormatFactory,
                dimensionStructureFactory,
                dimensionStructureLinkedListHelper
            );

            _masterDataBusinessLogic = new MasterDataBusinessLogic(_dbContextOptions, masterDataValidators);
            // "Given there is the MasterDataBusinessLogic"
            //    .x(() => _masterDataBusinessLogic = new MasterDataBusinessLogic(
            //         _dbContextOptions,
            //         masterDataValidators));

            using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
            {
                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();
                MasterDataDataSample.Populate(ctx);
            }
        }

        public void Dispose()
        {
            // _masterDataBusinessLogic.Dispose();
            (_serviceProvider as IDisposable)?.Dispose();
        }

        protected async Task<DomainModel.SourceFormat> GetTargetSourceFormat(
            string targetDomainObjectName,
            string targetDomainObjectSource)
        {
            if (targetDomainObjectSource.Equals(DomainObjectSourceStringEnum.Bag))
            {
                DomainModel.SourceFormat result = _sourceFormatBag.FirstOrDefault(
                        p => p.Value.Name == targetDomainObjectName)
                   .Value;
                return result;
            }

            if (targetDomainObjectSource.Equals(DomainObjectSourceStringEnum.ResultBag))
            {
                DomainModel.SourceFormat result = _sourceFormatSaveOperationResultBag.FirstOrDefault(
                        p => p.Value.Name == targetDomainObjectName)
                   .Value;
                return result;
            }

            throw new Exception($"No valid source for SourceFormat.");
        }

        protected async Task<DomainModel.DimensionStructure> GetTargetDimensionStructure(
            string targetDomainObjectName,
            string targetDomainObjectSource)
        {
            if (targetDomainObjectSource.Equals(DomainObjectSourceStringEnum.Bag))
            {
                DomainModel.DimensionStructure result = _dimensionStructureBag.FirstOrDefault(
                        p => p.Value.Name == targetDomainObjectName)
                   .Value;
                return result;
            }

            if (targetDomainObjectSource.Equals(DomainObjectSourceStringEnum.ResultBag))
            {
                DomainModel.DimensionStructure result = _dimensionStructureStoredObjectsBag.FirstOrDefault(
                        p => p.Value.Name == targetDomainObjectName)
                   .Value;
                return result;
            }

            throw new Exception($"No valid source for DimensionStructure.");
        }
    }
}