// <copyright file="Get_Should.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.Controllers.Integration.Tests.Dimension
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Threading.Tasks;

    using DomainModel;

    using FluentAssertions;

    using Utils.IntegrationTestFactories.Factories;

    using WebApp;

    using Xunit;
    using Xunit.Abstractions;

    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Reviewed.")]
    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "CA1707", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    [Collection("DigitalLibrary.IaC.MasterData.Controllers.Integration.Tests")]
    public class Get_Should : TestBase<Dimension>
    {
        public Get_Should(
            DiLibMasterDataWebApplicationFactory<Startup, Dimension> host,
            ITestOutputHelper testOutputHelper)
            : base(host, testOutputHelper)
        {
        }

        [Fact]
        public async Task Return_All()
        {
            // Arrange
            Dimension dimension1 = new Dimension
            {
                Name = "asdasd",
                Description = "asdad",
                IsActive = 1,
            };
            Dimension dimension1Result = await _masterDataHttpClient.AddDimensionAsync(dimension1)
               .ConfigureAwait(false);

            Dimension dimension2 = new Dimension
            {
                Name = "qweqwe",
                Description = "qweqwe",
                IsActive = 0,
            };
            Dimension dimension2Result = await _masterDataHttpClient.AddDimensionAsync(dimension2)
               .ConfigureAwait(false);

            // Act
            List<Dimension> result = await _masterDataHttpClient.GetDimensionsAsync().ConfigureAwait(false);

            // Assert
            result.Should().NotBeNull();
            result.Count.Should().Be(2);
            result.Where(p => p.Name == dimension1.Name).ToList().Count.Should().Be(1);
            result.Where(p => p.Name == dimension2.Name).ToList().Count.Should().Be(1);
        }
    }
}