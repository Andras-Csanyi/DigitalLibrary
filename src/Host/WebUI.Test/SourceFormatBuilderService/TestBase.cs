// <copyright file="TestBase.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.Ui.WebUI.Test.SourceFormatBuilderService
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    using MasterData.DomainModel;
    using MasterData.Validators;
    using MasterData.WebApi.Client;

    using Moq;

    using WebUi.Services;

    using Xunit.Abstractions;

    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "CA1707", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "CA1051", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1401", Justification = "Reviewed.")]
    public class TestBase
    {
        protected readonly Mock<IDomainEntityHelperService> _domainEntityHelperServiceMock =
            new Mock<IDomainEntityHelperService>();

        protected readonly Mock<IMasterDataValidators> _masterDataValidatorsMock = new Mock<IMasterDataValidators>();

        protected readonly Mock<IMasterDataHttpClient> _masterDataWebApiClientMock = new Mock<IMasterDataHttpClient>();

        protected readonly ITestOutputHelper _outputHelper;

        protected readonly SourceFormat _sourceFormat = new SourceFormat
        {
            Id = 100,
            Name = "Test Source Format",
            Desc = "Test Source Format Description",
            IsActive = 1,
            RootDimensionStructure = new DimensionStructure(),
            RootDimensionStructureId = 100,
        };

        protected readonly SourceFormat _sourceFormatDataOnTheFirstLevel = new SourceFormat
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

        protected readonly SourceFormat _sourceFormatDataOnTheSecondLevel = new SourceFormat
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

        protected readonly SourceFormat _sourceFormatDataOnTheThirdLevel = new SourceFormat
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
                                ChildDimensionStructures = new List<DimensionStructure>
                                {
                                    new DimensionStructure
                                    {
                                        Id = 301,
                                        Name = "third level first",
                                        Desc = "third level first description",
                                    },
                                    new DimensionStructure
                                    {
                                        Id = 302,
                                        Name = "third level second",
                                        Desc = "third level second description",
                                    },
                                },
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

        protected readonly SourceFormat _sourceFormatWithoutRootDimensionStructure = new SourceFormat
        {
            Id = 100,
            Name = "Test Source Format",
            Desc = "Test Source Format Description",
            IsActive = 1,
        };

        protected TestBase(ITestOutputHelper testOutputHelper)
        {
            _outputHelper = testOutputHelper;
        }
    }
}