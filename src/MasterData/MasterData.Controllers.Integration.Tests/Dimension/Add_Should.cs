// <copyright file="Add_Should.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.Controllers.Integration.Tests.Dimension
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.WebApi.Client;
    using DigitalLibrary.Utils.IntegrationTestFactories.Factories;
    using FluentAssertions;
    using WebApp;
    using Xunit;
    using Xunit.Abstractions;

    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Reviewed.")]
    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "CA1707", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    [Collection("DigitalLibrary.IaC.MasterData.Controllers.Integration.Tests")]
    public class Add_Should : TestBase<Dimension>
    {
        public Add_Should(
            DiLibMasterDataWebApplicationFactory<Startup, Dimension> host,
            ITestOutputHelper testOutputHelper)
            : base(host, testOutputHelper)
        {
        }

        [Fact]
        public async Task Add_TheItem()
        {
            // Arrange
            Dimension dimension = new Dimension
            {
                Name = "Add_TheItem",
                Description = "Add_TheItem",
                IsActive = 1,
            };

            // Act
            Dimension result = await _masterDataHttpClient.AddDimensionAsync(dimension).ConfigureAwait(false);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().BeGreaterThan(0);
            result.Name.Should().Be(dimension.Name);
            result.Description.Should().Be(dimension.Description);
            result.IsActive.Should().Be(dimension.IsActive);
        }

        [Fact]
        public async Task ThrowException_WhenNameUniqueIndexViolated()
        {
            // Arrange
            Dimension dimension = new Dimension
            {
                Name = "ThrowException_WhenNameUniqueIndexViolated",
                Description = "ThrowException_WhenNameUniqueIndexViolated",
                IsActive = 1,
            };
            Dimension dimensionResult = await _masterDataHttpClient.AddDimensionAsync(dimension).ConfigureAwait(false);

            // Act
            Func<Task> action = async () =>
            {
                await _masterDataHttpClient.AddDimensionAsync(dimension).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataHttpClientException>();
        }
    }
}