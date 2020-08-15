// <copyright file="Ctor_Validation_Should.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.Ui.WebUI.Test.SourceFormatBuilderService
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Net.Http;
    using System.Threading.Tasks;

    using FluentAssertions;

    using MasterData.Validators;
    using MasterData.WebApi.Client;

    using Utils.DiLibHttpClient;
    using Utils.Guards;

    using WebUi.Components.SourceFormatBuilder;
    using WebUi.Services;

    using Xunit;

    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Reviewed.")]
    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "CA1707", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    public class Ctor_Validation_Should : TestBase
    {
        public static IEnumerable<object[]> ThrowExceptionWhenInputIsNull => new List<object[]>
        {
            new object[] { null, null, null },
            new object[] { new MasterDataHttpClient(new DiLibHttpClient(new HttpClient())), null, null },
            new object[]
            {
                new MasterDataHttpClient(new DiLibHttpClient(new HttpClient())),
                new MasterDataValidators(
                    new DimensionValidator(),
                    new MasterDataDimensionValueValidator(),
                    new SourceFormatValidator(),
                    new DimensionStructureValidator(),
                    new DimensionStructureDimensionStructureValidator(),
                    new DimensionStructureQueryObjectValidator()),
                null,
            },
            new object[]
            {
                new MasterDataHttpClient(new DiLibHttpClient(new HttpClient())),
                new MasterDataValidators(
                    new DimensionValidator(),
                    new MasterDataDimensionValueValidator(),
                    new SourceFormatValidator(),
                    new DimensionStructureValidator(),
                    new DimensionStructureDimensionStructureValidator(),
                    new DimensionStructureQueryObjectValidator()),
                null,
            },
        };

        [Theory]
        [MemberData(nameof(ThrowExceptionWhenInputIsNull))]
        [SuppressMessage("ReSharper", "ObjectCreationAsStatement")]
        [SuppressMessage("ReSharper", "CA1806")]
        public void ThrowException_WhenInputIsNull(
            IMasterDataHttpClient masterDataHttpClient,
            IMasterDataValidators masterDataValidators,
            IDomainEntityHelperService domainEntityHelperService)
        {
            // Arrange

            // Act
            Action action = () =>
            {
                // ReSharper disable once CA1806
                new SourceFormatBuilderService(masterDataHttpClient, masterDataValidators,
                    domainEntityHelperService);
            };

            // Assert
            action.Should().ThrowExactly<GuardException>();
        }
    }
}