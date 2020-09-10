// <copyright file="SourceFormatFeature.Background.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    using DigitalLibrary.MasterData.BusinessLogic.Interfaces;
    using DigitalLibrary.MasterData.Ctx;
    using DigitalLibrary.MasterData.Validators;
    using DigitalLibrary.Utils.ControlPanel.DataSample.MasterData;
    using DigitalLibrary.Utils.Guards;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;

    using Xbehave;

    /// <summary>
    /// Background steps for <see cref="SourceFormat"/> related test cases.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "CA1707", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    public class MasterDataBusinessLogicFeature
    {
        public static readonly ILoggerFactory LoggerFactory = Microsoft.Extensions.Logging.LoggerFactory
           .Create(builder => { builder.AddDebug(); });

        protected IMasterDataBusinessLogic _masterDataBusinessLogic;

        private readonly string _testInfo;

        public MasterDataBusinessLogicFeature(string testInfo)
        {
            _testInfo = testInfo
             ?? throw new ArgumentNullException($"No testInfo is provided");
        }

        [Background]
        public void Background()
        {
            string msg = $"{_testInfo} cannot be null, empty or whitespace!";
            Check.NotNullOrEmptyOrWhitespace(_testInfo, msg);

            DbContextOptions<MasterDataContext> _dbContextOptions =
                new DbContextOptionsBuilder<MasterDataContext>()
                   .UseSqlite($"Data Source = {_testInfo}.sqlite")

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

            "Given there is the MasterDataBusinessLogic"
               .x(() => _masterDataBusinessLogic = new MasterDataBusinessLogic(
                    _dbContextOptions,
                    masterDataValidators));

            using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
            {
                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();
                MasterDataDataSample.Populate(ctx);
            }
        }
    }
}