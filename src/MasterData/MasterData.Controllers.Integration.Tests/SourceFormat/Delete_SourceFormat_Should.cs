// <copyright file="Delete_SourceFormat_Should.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.Controllers.Integration.Tests.SourceFormat
{
    using System;
    using System.Collections.Generic;
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
    public class Delete_SourceFormat_Should : TestBase<SourceFormat>
    {
        public Delete_SourceFormat_Should(
            DiLibMasterDataWebApplicationFactory<Startup, SourceFormat> host,
            ITestOutputHelper testOutputHelper)
            : base(host, testOutputHelper)
        {
        }

        [Fact(Skip = "Needs refactor")]
        public async Task DeleteTheItem()
        {
            // Arrange
            SourceFormat first = new SourceFormat
            {
                Name = "first",
                Desc = "second",
                IsActive = 1,
            };
            SourceFormat firstResult = await _masterDataHttpClient
               .AddSourceFormatAsync(first)
               .ConfigureAwait(false);

            SourceFormat second = new SourceFormat
            {
                Name = "second",
                Desc = "second",
                IsActive = 0,
            };
            SourceFormat secondResult = await _masterDataHttpClient
               .AddSourceFormatAsync(second)
               .ConfigureAwait(false);
            List<SourceFormat> origRes = await _masterDataHttpClient
               .GetSourceFormatsAsync()
               .ConfigureAwait(false);
            int origResCount = origRes.Count;

            // Act
            await _masterDataHttpClient.DeleteSourceFormatAsync(secondResult).ConfigureAwait(false);

            // Assert
            List<SourceFormat> res = await _masterDataHttpClient
               .GetSourceFormatsAsync()
               .ConfigureAwait(false);
            res.Count.Should().Be(origResCount - 1);
        }

        [Fact(Skip = "Needs refactor")]
        public void ThrowException_WhenEntityDoesntExist()
        {
            // Arrange
            SourceFormat sourceFormat = new SourceFormat { Id = 100 };

            // Act
            Func<Task> action = async () =>
            {
                await _masterDataHttpClient.DeleteSourceFormatAsync(sourceFormat)
                   .ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataHttpClientException>();
        }
    }
}