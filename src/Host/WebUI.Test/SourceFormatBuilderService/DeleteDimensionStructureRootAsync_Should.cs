// <copyright file="DeleteDimensionStructureRootAsync_Should.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.Ui.WebUI.Test.SourceFormatBuilderService
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Ui.WebUi.Components.SourceFormatBuilder;

    using FluentAssertions;

    using Moq;

    using Xunit;
    using Xunit.Abstractions;

    /// <summary>
    /// Testing when root <see cref="DimensionStructure"/> of <see cref="SourceFormat"/>
    /// is deleted.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "More readable test cases.")]
    [SuppressMessage("ReSharper", "CA1707", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    public class DeleteDimensionStructureRootAsync_Should : TestBase
    {
        public DeleteDimensionStructureRootAsync_Should(ITestOutputHelper outputHelper)
            : base(outputHelper)
        {
        }

        [Fact]
        public async Task SetRootDimensionStructure_To_Null()
        {
            // Arrange
            _masterDataWebApiClientMock
               .Setup(m => m.GetSourceFormatWithFullDimensionStructureTreeAsync(It.IsAny<SourceFormat>()))
               .ReturnsAsync(_sourceFormat);
            ISourceFormatBuilderService sourceFormatBuilderService = new SourceFormatBuilderService(
                _masterDataWebApiClientMock.Object,
                _masterDataValidatorsMock.Object,
                _domainEntityHelperServiceMock.Object);
            await sourceFormatBuilderService.OnUpdate(100).ConfigureAwait(false);

            // Act
            await sourceFormatBuilderService.DeleteDimensionStructureRootAsync()
               .ConfigureAwait(false);

            // Assert
            sourceFormatBuilderService.SourceFormat.RootDimensionStructure.Should().BeNull();
            sourceFormatBuilderService.SourceFormat.RootDimensionStructureId.Should().BeNull();
        }
    }
}