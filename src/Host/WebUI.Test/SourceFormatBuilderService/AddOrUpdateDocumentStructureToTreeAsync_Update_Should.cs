// <copyright file="AddOrUpdateDocumentStructureToTreeAsync_Update_Should.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.Ui.WebUI.Test.SourceFormatBuilderService
{
    using System;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.ViewModels;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Ui.WebUi.Components.SourceFormatBuilder;

    using FluentAssertions;

    using Moq;

    using Xunit;
    using Xunit.Abstractions;

    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Test cases are more readable.")]
    [SuppressMessage("ReSharper", "CA1707", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    public class AddOrUpdateDocumentStructureToTreeAsync_Update_Should : TestBase
    {
        public AddOrUpdateDocumentStructureToTreeAsync_Update_Should(ITestOutputHelper outputHelper)
            : base(outputHelper)
        {
        }

        [Fact]
        public void ReturnSilently_IfThereIsNoItemToUpdate()
        {
        }

        [Fact]
        public async Task UpdateItem_AtFirstLevel()
        {
            // Arrange
            _masterDataWebApiClientMock
               .Setup(m => m.GetSourceFormatWithFullDimensionStructureTreeAsync(It.IsAny<SourceFormat>()))
               .ReturnsAsync(_sourceFormatDataOnFirstLevel);

            DimensionStructure newOne = new DimensionStructure
            {
                Id = 103,
                Name = "new one",
                Desc = "new one desc",
            };

            _masterDataWebApiClientMock
               .Setup(m => m.GetDimensionStructureByIdAsync(It.IsAny<DimensionStructureQueryObject>()))
               .ReturnsAsync(newOne);

            ISourceFormatBuilderService sourceFormatBuilderService = new SourceFormatBuilderService(
                _masterDataWebApiClientMock.Object,
                _masterDataValidatorsMock.Object,
                _domainEntityHelperServiceMock.Object);

            await sourceFormatBuilderService.OnUpdate(100).ConfigureAwait(false);

            DimensionStructure toBeReplaced = _sourceFormatDataOnFirstLevel.RootDimensionStructure
               .ChildDimensionStructures
               .ElementAt(0);

            // Act
            await sourceFormatBuilderService.AddOrUpdateDocumentStructureToTreeAsync(
                    newOne,
                    toBeReplaced.Guid)
               .ConfigureAwait(false);

            // Assert
            sourceFormatBuilderService.SourceFormat.RootDimensionStructure
               .ChildDimensionStructures
               .Where(g => g.Guid == newOne.Guid)
               .ToList()
               .Count
               .Should().Be(1);
        }

        [Fact]
        public void UpdateItem_AtSecondLevel()
        {
        }

        [Fact]
        public void UpdateItem_AtThirdLevel()
        {
        }

        [Fact]
        public void UpdateItem_RootDimension()
        {
        }
    }
}