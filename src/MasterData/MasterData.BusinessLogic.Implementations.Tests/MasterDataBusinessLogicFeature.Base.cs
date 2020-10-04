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

    using DigitalLibrary.MasterData.BusinessLogic.Implementations.Dimension;
    using DigitalLibrary.MasterData.BusinessLogic.Implementations.DimensionStructure;
    using DigitalLibrary.MasterData.BusinessLogic.Implementations.DimensionValue;
    using DigitalLibrary.MasterData.BusinessLogic.Implementations.SourceFormat;
    using DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.Entities;
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

        protected Dictionary<string, DomainModel.DimensionStructure> _dimensionStructureBag =
            new Dictionary<string, DomainModel.DimensionStructure>();

        protected IMasterDataTestHelper _masterDataTestHelper;

        protected MasterDataBusinessLogicFeature(
            string testInfo,
            ITestOutputHelper testOutputHelper)
        {
            _testInfo = testInfo;
            Check.NotNullOrEmptyOrWhitespace(_testInfo);
            Check.IsNotNull(testOutputHelper);

            _dbContextOptions = new DbContextOptionsBuilder<MasterDataContext>()
               .UseSqlite($"Data Source = {_testInfo}.sqlite")

                // .UseNpgsql("Server=127.0.0.1;Port=5432;Database=dilib;User Id=andrascsanyi;")
                // .UseLoggerFactory(MasterDataLogger)
               .UseInternalServiceProvider(_serviceProvider)
               .EnableDetailedErrors()
               .EnableSensitiveDataLogging()
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

            IMasterDataDimensionBusinessLogic masterDataDimensionBusinessLogic = new MasterDataDimensionBusinessLogic(
                _dbContextOptions, masterDataValidators);
            IMasterDataDimensionStructureBusinessLogic masterDataDimensionStructureBusinessLogic =
                new MasterDataDimensionStructureBusinessLogic(_dbContextOptions, masterDataValidators);
            IMasterDataDimensionValueBusinessLogic masterDataDimensionValueBusinessLogic =
                new MasterDataDimensionValueBusinessLogic(_dbContextOptions, masterDataValidators);
            IMasterDataSourceFormatBusinessLogic masterDataSourceFormatBusinessLogic =
                new MasterDataSourceFormatBusinessLogic(_dbContextOptions, masterDataValidators);

            _masterDataBusinessLogic = new MasterDataBusinessLogic(
                masterDataDimensionBusinessLogic,
                masterDataDimensionStructureBusinessLogic,
                masterDataDimensionValueBusinessLogic,
                masterDataSourceFormatBusinessLogic);
            // "Given there is the MasterDataBusinessLogic"
            //    .x(() => _masterDataBusinessLogic = new MasterDataBusinessLogic(
            //         _dbContextOptions,
            //         masterDataValidators));

            using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
            {
                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();
                // MasterDataDataSample.Populate(ctx);
            }

            IStringHelper stringHelper = new StringHelper();
            ISourceFormatFactory sourceFormatFactory = new SourceFormatFactory(stringHelper);
            IDimensionStructureFactory dimensionStructureFactory = new DimensionStructureFactory(stringHelper);
            IDimensionStructureLinkedListHelper dimensionStructureLinkedListHelper =
                new DimensionStructureLinkedListHelper();
            _masterDataTestHelper = new MasterDataTestHelper(
                sourceFormatFactory,
                dimensionStructureFactory,
                dimensionStructureLinkedListHelper);
        }

        [BeforeScenario]
        public void Background()
        {
        }

        public void Dispose()
        {
            // _masterDataBusinessLogic.Dispose();
            (_serviceProvider as IDisposable)?.Dispose();
        }

        protected async Task SourceFormatDomainObjectTypeIsSaved(DomainObjectIsSavedEntity instance)
        {
            DomainModel.SourceFormat toSave = _sourceFormatBag[instance.Key];
            DomainModel.SourceFormat result = await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AddSourceFormatAsync(toSave)
               .ConfigureAwait(false);

            _sourceFormatBag.Add(instance.ResultKey, result);
        }

        protected async Task DimensionStructureDomainObjectTypeIsSaved(DomainObjectIsSavedEntity instance)
        {
            DomainModel.DimensionStructure toSave = _dimensionStructureBag.FirstOrDefault(
                p => p.Key.Equals(instance.Key)).Value;
            DomainModel.DimensionStructure result = await _masterDataBusinessLogic
               .MasterDataDimensionStructureBusinessLogic
               .AddDimensionStructureAsync(toSave)
               .ConfigureAwait(false);
            _dimensionStructureBag.Add(instance.ResultKey, result);
        }
    }
}