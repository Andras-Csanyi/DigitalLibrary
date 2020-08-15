// <copyright file="Update_SourceFormat_NameDescIsActive_Validation_Should.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.Controllers.Integration.Tests.SourceFormat
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DomainModel;

    using FluentAssertions;

    using Utils.IntegrationTestFactories.Factories;

    using Validators.TestData;

    using WebApi.Client;

    using WebApp;

    using Xunit;
    using Xunit.Abstractions;

    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "CA1707")]
    [Collection("DigitalLibrary.IaC.MasterData.Controllers.Integration.Tests")]
    [SuppressMessage("ReSharper", "TooManyArguments")]
    public class Update_SourceFormat_NameDescIsActive_Validation_Should : TestBase<SourceFormat>
    {
        public Update_SourceFormat_NameDescIsActive_Validation_Should(
            DiLibMasterDataWebApplicationFactory<Startup, SourceFormat> host,
            ITestOutputHelper testOutputHelper) : base(host, testOutputHelper)
        {
        }

        [Theory]
        [MemberData(nameof(MasterData_DimensionStructure_TestData.ModifyTopDimensionStructure_Validation_TestData),
            MemberType = typeof(MasterData_DimensionStructure_TestData))]
        public void ThrowException_WhenInputIsInvalid(
            long id,
            string name,
            string desc,
            int isActive)
        {
            // Arrange
            SourceFormat sourceFormat = new SourceFormat()
            {
                Id = id,
                Name = name,
                Desc = desc,
                IsActive = isActive
            };

            // Act
            Func<Task> action = async () =>
            {
                await _masterDataHttpClient.UpdateSourceFormatAsync(sourceFormat).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataHttpClientException>();
        }

        [Fact]
        public void ThrowException_WhenInputIsNull()
        {
            // Arrange

            // Act
            Func<Task> action = async () =>
            {
                await _masterDataHttpClient.UpdateSourceFormatAsync(null).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataHttpClientException>();
        }
    }
}