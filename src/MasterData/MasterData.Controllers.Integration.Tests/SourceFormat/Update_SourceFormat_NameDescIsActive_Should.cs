// <copyright file="Update_SourceFormat_NameDescIsActive_Should.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.Controllers.Integration.Tests.SourceFormat
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
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
    public class Update_SourceFormat_NameDescIsActive_Should : TestBase<SourceFormat>
    {
        public Update_SourceFormat_NameDescIsActive_Should(
            DiLibMasterDataWebApplicationFactory<Startup, SourceFormat> host,
            ITestOutputHelper testOutputHelper)
            : base(host, testOutputHelper)
        {
        }

        [Fact(Skip = "Needs refactor")]
        public async Task Update_NameDescIsActive()
        {
            // Arrange
            string name = "name";
            string desc = "desc";
            int isActive = 0;

            SourceFormat orig = new SourceFormat
            {
                Name = "orig",
                Desc = "orig",
                IsActive = 1,
            };
            SourceFormat origResult = await _masterDataHttpClient
               .AddSourceFormatAsync(orig)
               .ConfigureAwait(false);

            origResult.Name = name;
            origResult.Desc = desc;
            origResult.IsActive = isActive;

            // Act
            SourceFormat result = await _masterDataHttpClient
               .UpdateSourceFormatAsync(origResult)
               .ConfigureAwait(false);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(origResult.Id);
            result.Name.Should().Be(name);
            result.Desc.Should().Be(desc);
            result.IsActive.Should().Be(isActive);
        }
    }
}