// <copyright file="Count_SourceFormat_Should.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.SourceFormat
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DomainModel;

    using FluentAssertions;

    using Utils.ControlPanel.DataSample.MasterData;

    using Xunit;

    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Reviewed.")]
    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "CA1707", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    public class Count_SourceFormat_Should : TestBase
    {
        public Count_SourceFormat_Should()
            : base(TestInfo)
        {
        }

        private const string TestInfo = nameof(Count_SourceFormat_Should);

        [Fact]
        public async Task ReturnsAll()
        {
            // Arrange
            SourceFormat sourceFormat = new SourceFormat
            {
                Name = "name",
                Desc = "desc",
                IsActive = 1,
            };

            SourceFormat result = await masterDataBusinessLogic.AddSourceFormatAsync(
                sourceFormat).ConfigureAwait(false);

            SourceFormat sourceFormat2 = new SourceFormat
            {
                Name = "name2",
                Desc = "desc2",
                IsActive = 0,
            };

            SourceFormat result2 = await masterDataBusinessLogic.AddSourceFormatAsync(
                sourceFormat2).ConfigureAwait(false);

            // Act
            long count = await masterDataBusinessLogic.CountSourceFormatsAsync().ConfigureAwait(false);

            // Act
            int expectedAmount = MasterDataDataSample.GetSourceFormatAmount() + 2;
            count.Should().Be(expectedAmount);
        }

        [Fact]
        public async Task ReturnsZero_WhenThereAreNoTopDimensionstructures()
        {
            // Arrange

            // Act
            long count = await masterDataBusinessLogic.CountSourceFormatsAsync()
               .ConfigureAwait(false);

            // Assert
            int expectedAmount = MasterDataDataSample.GetSourceFormatAmount();
            count.Should().Be(expectedAmount);
        }
    }
}