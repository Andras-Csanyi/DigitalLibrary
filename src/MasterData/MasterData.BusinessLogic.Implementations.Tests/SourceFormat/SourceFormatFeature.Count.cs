// <copyright file="Count_SourceFormat_Should.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.SourceFormat
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.ControlPanel.DataSample.MasterData;

    using FluentAssertions;

    using Xbehave;

    using Xunit;

    public partial class SourceFormatFeature
    {
        [Scenario]
        public async Task Count_ReturnsAllIncludingActiveAndInactive()
        {
            SourceFormat sourceFormat = null;
            SourceFormat sourceFormat2 = null;
            long count = 0;

            "Given we have an active source format."
               .x(() => sourceFormat = new SourceFormat
                {
                    Name = "name",
                    Desc = "desc",
                    IsActive = 1,
                });

            "And it is added to the database"
               .x(async () => await _masterDataBusinessLogic.AddSourceFormatAsync(
                    sourceFormat).ConfigureAwait(false));

            "And there is another, but inactive source format"
               .x(() => sourceFormat2 = new SourceFormat
                {
                    Name = "name2",
                    Desc = "desc2",
                    IsActive = 0,
                });

            "And it is also added to the database"
               .x(async () => await _masterDataBusinessLogic.AddSourceFormatAsync(
                    sourceFormat2).ConfigureAwait(false));

            "When I ask how many source format in the database"
               .x(async () => count = await _masterDataBusinessLogic.CountSourceFormatsAsync().ConfigureAwait(false));

            "Then the active and inactive is counted"
               .x(() => count.Should().Be(count));
        }

        [Scenario]
        public async Task Count_ReturnsZero_WhenThereAreNoSourceFormatsInTheDatabase()
        {
            long count = 0;

            "When the database has zero SourceFormats"
               .x(async () => count = await _masterDataBusinessLogic.CountSourceFormatsAsync()
                   .ConfigureAwait(false));

            int expectedAmount = MasterDataDataSample.GetSourceFormatAmount();

            "Then it returns zero"
               .x(() => count.Should().Be(expectedAmount));
        }
    }
}