// <copyright file="UpdateDocumentStructureToTreeAsync_Update_Should.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.Ui.WebUI.Test.SourceFormatBuilderService
{
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

    /// <summary>
    ///     Integration test cases when a <see cref="DocumentStructure" /> is updated in the tree.
    ///     The test cases cover the basic functionality.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Test cases are more readable.")]
    [SuppressMessage("ReSharper", "CA1707", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    public class UpdateDocumentStructureToTreeAsync_Update_Should : TestBase
    {
        public UpdateDocumentStructureToTreeAsync_Update_Should(ITestOutputHelper outputHelper)
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
               .ReturnsAsync(_sourceFormatDataOnTheFirstLevel);

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

            DimensionStructure toBeReplaced = _sourceFormatDataOnTheFirstLevel.RootDimensionStructure
               .ChildDimensionStructures
               .ElementAt(0);

            // Act
            await sourceFormatBuilderService.UpdateDocumentStructureInTheTreeAsync(
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

            sourceFormatBuilderService.SourceFormat.RootDimensionStructure
               .ChildDimensionStructures
               .Where(g => g.Guid == toBeReplaced.Guid)
               .ToList()
               .Count
               .Should().Be(0);

            sourceFormatBuilderService.SourceFormat.RootDimensionStructure
               .ChildDimensionStructures
               .Count
               .Should().Be(2);
        }

        [Fact]
        public async Task UpdateItem_AtSecondLevel()
        {
            // Arrange
            _masterDataWebApiClientMock
               .Setup(m => m.GetSourceFormatWithFullDimensionStructureTreeAsync(It.IsAny<SourceFormat>()))
               .ReturnsAsync(_sourceFormatDataOnTheSecondLevel);

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

            DimensionStructure firstLevelNode = _sourceFormatDataOnTheSecondLevel.RootDimensionStructure
               .ChildDimensionStructures
               .ElementAt(0);

            DimensionStructure toBeReplaced = firstLevelNode
               .ChildDimensionStructures
               .ElementAt(1);

            // Act
            await sourceFormatBuilderService.UpdateDocumentStructureInTheTreeAsync(
                    newOne,
                    toBeReplaced.Guid)
               .ConfigureAwait(false);

            // Assert
            sourceFormatBuilderService.SourceFormat.RootDimensionStructure
               .ChildDimensionStructures
               .First(g => g.Guid == firstLevelNode.Guid)
               .ChildDimensionStructures
               .Where(r => r.Guid == newOne.Guid)
               .ToList()
               .Count
               .Should().Be(1);

            sourceFormatBuilderService.SourceFormat.RootDimensionStructure
               .ChildDimensionStructures
               .First(g => g.Guid == firstLevelNode.Guid)
               .ChildDimensionStructures
               .Where(g => g.Guid == toBeReplaced.Guid)
               .ToList()
               .Count
               .Should().Be(0);

            sourceFormatBuilderService.SourceFormat.RootDimensionStructure
               .ChildDimensionStructures
               .First(g => g.Guid == firstLevelNode.Guid)
               .ChildDimensionStructures
               .Count
               .Should().Be(2);
        }

        [Fact]
        public async Task UpdateItem_AtThirdLevel()
        {
            // Arrange
            _masterDataWebApiClientMock
               .Setup(m => m.GetSourceFormatWithFullDimensionStructureTreeAsync(It.IsAny<SourceFormat>()))
               .ReturnsAsync(_sourceFormatDataOnTheThirdLevel);

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

            DimensionStructure firstLevelNode = _sourceFormatDataOnTheThirdLevel.RootDimensionStructure
               .ChildDimensionStructures
               .ElementAt(0);

            DimensionStructure secondLevelNode = firstLevelNode
               .ChildDimensionStructures
               .ElementAt(1);

            DimensionStructure toBeReplaced = secondLevelNode
               .ChildDimensionStructures
               .ElementAt(1);

            // Act
            await sourceFormatBuilderService.UpdateDocumentStructureInTheTreeAsync(
                    newOne,
                    toBeReplaced.Guid)
               .ConfigureAwait(false);

            // Assert
            sourceFormatBuilderService.SourceFormat.RootDimensionStructure
               .ChildDimensionStructures
               .First(n => n.Guid == firstLevelNode.Guid)
               .ChildDimensionStructures
               .First(g => g.Guid == secondLevelNode.Guid)
               .ChildDimensionStructures
               .Where(r => r.Guid == newOne.Guid)
               .ToList()
               .Count
               .Should().Be(1);

            sourceFormatBuilderService.SourceFormat.RootDimensionStructure
               .ChildDimensionStructures
               .First(n => n.Guid == firstLevelNode.Guid)
               .ChildDimensionStructures
               .First(g => g.Guid == secondLevelNode.Guid)
               .ChildDimensionStructures
               .Where(g => g.Guid == toBeReplaced.Guid)
               .ToList()
               .Count
               .Should().Be(0);

            sourceFormatBuilderService.SourceFormat.RootDimensionStructure
               .ChildDimensionStructures
               .First(n => n.Guid == firstLevelNode.Guid)
               .ChildDimensionStructures
               .First(g => g.Guid == secondLevelNode.Guid)
               .ChildDimensionStructures
               .Count
               .Should().Be(2);
        }

        [Fact]
        public async Task UpdateItem_RootDimension()
        {
            // Arrange
            _masterDataWebApiClientMock
               .Setup(m => m.GetSourceFormatWithFullDimensionStructureTreeAsync(It.IsAny<SourceFormat>()))
               .ReturnsAsync(_sourceFormatDataOnTheThirdLevel);

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

            DimensionStructure toBeReplaced = _sourceFormatDataOnTheThirdLevel.RootDimensionStructure;

            // Act
            await sourceFormatBuilderService.UpdateDocumentStructureInTheTreeAsync(
                    newOne,
                    toBeReplaced.Guid)
               .ConfigureAwait(false);

            // Assert
            sourceFormatBuilderService.SourceFormat.RootDimensionStructure
               .ChildDimensionStructures
               .Count
               .Should().Be(0);

            sourceFormatBuilderService.SourceFormat.RootDimensionStructure.Name.Should().Be(newOne.Name);
            sourceFormatBuilderService.SourceFormat.RootDimensionStructure.Desc.Should().Be(newOne.Desc);
            sourceFormatBuilderService.SourceFormat.RootDimensionStructure.Guid.Should().Be(newOne.Guid);
        }
    }
}