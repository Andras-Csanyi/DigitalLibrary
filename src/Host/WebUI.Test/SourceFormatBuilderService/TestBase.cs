// <copyright file="TestBase.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.Ui.WebUI.Test.SourceFormatBuilderService
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.Validators;
    using DigitalLibrary.MasterData.WebApi.Client;
    using DigitalLibrary.Ui.WebUi.Services;

    using Moq;

    using Xunit.Abstractions;

    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Reviewed.")]
    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "CA1707", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    public class TestBase
    {
        protected readonly ITestOutputHelper _outputHelper;

        protected readonly Mock<IDomainEntityHelperService> _domainEntityHelperServiceMock =
            new Mock<IDomainEntityHelperService>();

        protected readonly Mock<IMasterDataValidators> _masterDataValidatorsMock = new Mock<IMasterDataValidators>();

        protected readonly Mock<IMasterDataHttpClient> _masterDataWebApiClientMock = new Mock<IMasterDataHttpClient>();

        protected readonly SourceFormat _sourceFormat = new SourceFormat
        {
            Id = 100,
            Name = "Test Source Format",
            Desc = "Test Source Format Description",
            IsActive = 1,
            RootDimensionStructure = new DimensionStructure(),
            RootDimensionStructureId = 100,
        };

        protected SourceFormat _sourceFormatDataOnTheFirstLevel = new SourceFormat
        {
            Id = 100,
            Name = "Test Source Format",
            Desc = "Test Source Format Description",
            IsActive = 1,
            RootDimensionStructure = new DimensionStructure
            {
                Id = 100,
                Name = "first level",
                Desc = "first level description",
                ChildDimensionStructures = new List<DimensionStructure>
                {
                    new DimensionStructure
                    {
                        Id = 101,
                        Name = "first level first",
                        Desc = "first level first description",
                    },
                    new DimensionStructure
                    {
                        Id = 102,
                        Name = "first level second",
                        Desc = "first level second desc",
                    },
                },
            },
            RootDimensionStructureId = 100,
        };

        protected SourceFormat _sourceFormatDataOnTheSecondLevel = new SourceFormat
        {
            Id = 100,
            Name = "Test Source Format",
            Desc = "Test Source Format Description",
            IsActive = 1,
            RootDimensionStructure = new DimensionStructure
            {
                Id = 100,
                Name = "first level",
                Desc = "first level description",
                ChildDimensionStructures = new List<DimensionStructure>
                {
                    new DimensionStructure
                    {
                        Id = 101,
                        Name = "first level first",
                        Desc = "first level first description",
                        ChildDimensionStructures = new List<DimensionStructure>
                        {
                            new DimensionStructure
                            {
                                Id = 201,
                                Name = "second level first",
                                Desc = "second level first description",
                            },
                            new DimensionStructure
                            {
                                Id = 202,
                                Name = "second level second",
                                Desc = "second level second description",
                            },
                        },
                    },
                    new DimensionStructure
                    {
                        Id = 102,
                        Name = "first level second",
                        Desc = "first level second desc",
                    },
                },
            },
            RootDimensionStructureId = 100,
        };

        protected SourceFormat _sourceFormatWithoutRootDimensionStructure = new SourceFormat
        {
            Id = 100,
            Name = "Test Source Format",
            Desc = "Test Source Format Description",
            IsActive = 1,
        };

        protected MasterDataValidators GetMasterDataValidators()
        {
            DimensionValidator dimensionValidator = new DimensionValidator();
            MasterDataDimensionValueValidator masterDataDimensionValueValidator =
                new MasterDataDimensionValueValidator();
            SourceFormatValidator sourceFormatValidator = new SourceFormatValidator();
            DimensionStructureValidator dimensionStructureValidator = new DimensionStructureValidator();
            DimensionStructureDimensionStructureValidator dimensionStructureDimensionStructureValidator =
                new DimensionStructureDimensionStructureValidator();
            DimensionStructureQueryObjectValidator dimensionStructureQueryObjectValidator =
                new DimensionStructureQueryObjectValidator();

            MasterDataValidators validators = new MasterDataValidators(
                dimensionValidator,
                masterDataDimensionValueValidator,
                sourceFormatValidator,
                dimensionStructureValidator,
                dimensionStructureDimensionStructureValidator,
                dimensionStructureQueryObjectValidator);
            return validators;
        }

        public TestBase(ITestOutputHelper testOutputHelper)
        {
            _outputHelper = testOutputHelper;
        }
    }
}