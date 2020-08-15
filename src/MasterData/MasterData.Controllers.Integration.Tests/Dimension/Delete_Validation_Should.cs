// <copyright file="Delete_Validation_Should.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.Controllers.Integration.Tests.Dimension
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DomainModel;

    using FluentAssertions;

    using Utils.IntegrationTestFactories.Factories;

    using WebApi.Client;

    using WebApp;

    using Xunit;
    using Xunit.Abstractions;

    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Reviewed.")]
    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "CA1707", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    [Collection("DigitalLibrary.IaC.MasterData.Controllers.Integration.Tests")]
    public class Delete_Validation_Should : TestBase<Dimension>
    {
        public Delete_Validation_Should(
            DiLibMasterDataWebApplicationFactory<Startup, Dimension> host,
            ITestOutputHelper testOutputHelper)
            : base(host, testOutputHelper)
        {
        }

        [Fact]
        public void ThrowException_WhenInputIsInvalid()
        {
            // Arrange
            Dimension dimension = new Dimension
            {
                Id = 0,
            };

            // Act
            Func<Task> action = async () =>
            {
                await _masterDataHttpClient.DeleteDimensionAsync(dimension).ConfigureAwait(false);
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
                await _masterDataHttpClient.DeleteDimensionAsync(null).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataHttpClientException>();
        }
    }
}