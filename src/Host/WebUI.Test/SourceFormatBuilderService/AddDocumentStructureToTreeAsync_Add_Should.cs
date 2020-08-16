// <copyright file="AddDocumentStructureToTreeAsync_Add_Should.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.Ui.WebUI.Test.SourceFormatBuilderService
{
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Ui.WebUi.Components.SourceFormatBuilder;

    using FluentAssertions;

    using Moq;

    using Xunit;
    using Xunit.Abstractions;

    /// <summary>
    ///     Integration tests for the scenario where new <see cref="DocumentStructure" />s are added
    ///     to the <see cref="DocumentStructure" /> tree.
    ///     The tests below covers the basic functionality.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "More readable method names.")]
    [SuppressMessage("ReSharper", "CA1707", Justification = "More readable test method names.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Tests.")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException", Justification = "Reviewed.")]
    public class AddDocumentStructureToTreeAsync_Add_Should : TestBase
    {
        public AddDocumentStructureToTreeAsync_Add_Should(ITestOutputHelper outputHelper)
            : base(outputHelper)
        {
        }

        [Fact]
        public async Task AddItem_ToEmpty_RootDimensionStructure()
        {
            // Arrange
            _masterDataWebApiClientMock
               .Setup(m => m.GetSourceFormatWithFullDimensionStructureTreeAsync(It.IsAny<SourceFormat>()))
               .ReturnsAsync(_sourceFormat);

            ISourceFormatBuilderService sourceFormatBuilderService = new SourceFormatBuilderService(
                _masterDataWebApiClientMock.Object,
                _masterDataValidatorsMock.Object,
                _domainEntityHelperServiceMock.Object);

            DimensionStructure newOne = new DimensionStructure
            {
                Name = "something new",
                Desc = "description",
            };
            await sourceFormatBuilderService.OnUpdate(100).ConfigureAwait(false);

            // Act
            await sourceFormatBuilderService.AddOrReplaceDocumentStructureToTreeAsync(
                    newOne,
                    _sourceFormat.RootDimensionStructure.Guid)
               .ConfigureAwait(false);

            // Assert
            sourceFormatBuilderService.SourceFormat.RootDimensionStructure
               .ChildDimensionStructures
               .Count
               .Should()
               .Be(1);

            sourceFormatBuilderService.SourceFormat.RootDimensionStructure
               .ChildDimensionStructures
               .ElementAt(0)
               .Name.Should().Be(newOne.Name);

            sourceFormatBuilderService.SourceFormat.RootDimensionStructure
               .ChildDimensionStructures
               .ElementAt(0)
               .Desc.Should().Be(newOne.Desc);
        }

        [Fact]
        public async Task AddItemTo_FirstLevel_EmptyLengthList()
        {
            // Arrange
            DimensionStructure firstOne = new DimensionStructure
            {
                Name = "first one",
                Desc = "second one",
            };
            _sourceFormat.RootDimensionStructure.ChildDimensionStructures.Add(firstOne);

            _masterDataWebApiClientMock
               .Setup(m => m.GetSourceFormatWithFullDimensionStructureTreeAsync(It.IsAny<SourceFormat>()))
               .ReturnsAsync(_sourceFormat);

            ISourceFormatBuilderService sourceFormatBuilderService = new SourceFormatBuilderService(
                _masterDataWebApiClientMock.Object,
                _masterDataValidatorsMock.Object,
                _domainEntityHelperServiceMock.Object);

            DimensionStructure newOne = new DimensionStructure
            {
                Name = "something new",
                Desc = "description",
            };
            await sourceFormatBuilderService.OnUpdate(100).ConfigureAwait(false);

            // Act
            await sourceFormatBuilderService.AddOrReplaceDocumentStructureToTreeAsync(
                    newOne,
                    _sourceFormat.RootDimensionStructure.Guid)
               .ConfigureAwait(false);

            // Assert
            sourceFormatBuilderService.SourceFormat.RootDimensionStructure
               .ChildDimensionStructures
               .Count
               .Should()
               .Be(2);

            DimensionStructure res = sourceFormatBuilderService.SourceFormat.RootDimensionStructure
               .ChildDimensionStructures
               .FirstOrDefault(p => p.Guid == newOne.Guid);
            res.Should().NotBeNull();
            res.Name.Should().Be(newOne.Name);
            res.Desc.Should().Be(newOne.Desc);
        }

        [Fact]
        public async Task AddItemTo_FirstLevel_WhenListHasMultipleItems()
        {
            DimensionStructure toRootFirst = new DimensionStructure
            {
                Name = "toRootFirst name",
                Desc = "toRootFirst desc",
            };

            DimensionStructure firstLevelFirst = new DimensionStructure
            {
                Name = "namefirstLevelFirst",
                Desc = "descfirstLevelFirst",
            };

            DimensionStructure firstLevelSecond = new DimensionStructure
            {
                Name = "namefirstLevelSecond",
                Desc = "descfirstLevelSecond",
            };
            toRootFirst.ChildDimensionStructures.Add(firstLevelFirst);
            toRootFirst.ChildDimensionStructures.Add(firstLevelSecond);

            DimensionStructure toRootSecond = new DimensionStructure
            {
                Name = "toRootSecond name",
                Desc = "toRootSecond desc",
            };

            _sourceFormat.RootDimensionStructure.ChildDimensionStructures.Add(toRootFirst);
            _sourceFormat.RootDimensionStructure.ChildDimensionStructures.Add(toRootSecond);

            _masterDataWebApiClientMock
               .Setup(m => m.GetSourceFormatWithFullDimensionStructureTreeAsync(It.IsAny<SourceFormat>()))
               .ReturnsAsync(_sourceFormat);

            ISourceFormatBuilderService sourceFormatBuilderService = new SourceFormatBuilderService(
                _masterDataWebApiClientMock.Object,
                _masterDataValidatorsMock.Object,
                _domainEntityHelperServiceMock.Object);
            await sourceFormatBuilderService.OnUpdate(100).ConfigureAwait(false);

            DimensionStructure toFirstLevel = new DimensionStructure
            {
                Name = "toFirstLevel name",
                Desc = "toFirstLevel desc",
            };

            // Act
            await sourceFormatBuilderService.AddOrReplaceDocumentStructureToTreeAsync(
                    toFirstLevel,
                    toRootFirst.Guid)
               .ConfigureAwait(false);

            // Assert
            sourceFormatBuilderService.SourceFormat.RootDimensionStructure.ChildDimensionStructures
               .Count
               .Should().Be(2);

            DimensionStructure toFirstResult = sourceFormatBuilderService.SourceFormat
               .RootDimensionStructure
               .ChildDimensionStructures
               .FirstOrDefault(p => p.Guid == toRootFirst.Guid);

            toFirstResult.ChildDimensionStructures.Count
               .Should().Be(3);

            DimensionStructure res = toFirstResult
               .ChildDimensionStructures
               .FirstOrDefault(p => p.Guid == toFirstLevel.Guid);
            res.Should().NotBeNull();
            res.Name.Should().Be(toFirstLevel.Name);
            res.Desc.Should().Be(toFirstLevel.Desc);
        }

        [Fact]
        public async Task AddItemTo_FirstLevel_WhenListIsEmpty()
        {
            DimensionStructure toRootFirst = new DimensionStructure
            {
                Name = "toRootFirst name",
                Desc = "toRootFirst desc",
            };

            DimensionStructure toRootSecond = new DimensionStructure
            {
                Name = "toRootSecond name",
                Desc = "toRootSecond desc",
            };

            _sourceFormat.RootDimensionStructure.ChildDimensionStructures.Add(toRootFirst);
            _sourceFormat.RootDimensionStructure.ChildDimensionStructures.Add(toRootSecond);

            _masterDataWebApiClientMock
               .Setup(m => m.GetSourceFormatWithFullDimensionStructureTreeAsync(It.IsAny<SourceFormat>()))
               .ReturnsAsync(_sourceFormat);

            ISourceFormatBuilderService sourceFormatBuilderService = new SourceFormatBuilderService(
                _masterDataWebApiClientMock.Object,
                _masterDataValidatorsMock.Object,
                _domainEntityHelperServiceMock.Object);
            await sourceFormatBuilderService.OnUpdate(100).ConfigureAwait(false);

            DimensionStructure toFirstLevel = new DimensionStructure
            {
                Name = "toFirstLevel name",
                Desc = "toFirstLevel desc",
            };

            // Act
            await sourceFormatBuilderService.AddOrReplaceDocumentStructureToTreeAsync(
                    toFirstLevel,
                    toRootFirst.Guid)
               .ConfigureAwait(false);

            // Assert
            sourceFormatBuilderService.SourceFormat.RootDimensionStructure.ChildDimensionStructures
               .Count
               .Should().Be(2);

            DimensionStructure toFirstResult = sourceFormatBuilderService.SourceFormat
               .RootDimensionStructure
               .ChildDimensionStructures
               .FirstOrDefault(p => p.Guid == toRootFirst.Guid);

            toFirstResult.ChildDimensionStructures.Count
               .Should().Be(1);

            DimensionStructure res = toFirstResult
               .ChildDimensionStructures
               .FirstOrDefault(p => p.Guid == toFirstLevel.Guid);
            res.Should().NotBeNull();
            res.Name.Should().Be(toFirstLevel.Name);
            res.Desc.Should().Be(toFirstLevel.Desc);
        }
    }
}