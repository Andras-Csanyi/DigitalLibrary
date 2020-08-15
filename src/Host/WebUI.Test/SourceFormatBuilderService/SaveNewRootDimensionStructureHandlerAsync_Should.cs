// <copyright file="SaveNewRootDimensionStructureHandlerAsync_Should.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.Ui.WebUI.Test.SourceFormatBuilderService
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using FluentAssertions;

    using FluentValidation;

    using MasterData.DomainModel;

    using WebUi.Components.SourceFormatBuilder;

    using Xunit;

    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Reviewed.")]
    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "CA1707", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    public class SaveNewRootDimensionStructureHandlerAsync_Should : TestBase
    {
        [Theory(Skip = "tmp")]
        [InlineData(1, "name", "desc", 1)]
        [InlineData(0, "", "desc", 1)]
        [InlineData(0, null, "desc", 1)]
        [InlineData(0, "na", "desc", 1)]
        [InlineData(0, "name", "", 1)]
        [InlineData(0, "name", null, 1)]
        [InlineData(0, "name", "de", 1)]
        [InlineData(0, "name", "desc", 2)]
        [SuppressMessage("ReSharper", "TooManyArguments")]
        public void ThrowException_WhenDimensionStructure_InputIsInvalid(
            long id,
            string name,
            string desc,
            int isActive)
        {
            // Arrange
            SourceFormatBuilderService sourceFormatBuilderService = new SourceFormatBuilderService(
                _masterDataWebApiClientMock.Object,
                _masterDataValidatorsMock.Object,
                _domainEntityHelperServiceMock.Object);

            DimensionStructure dimensionStructure = new DimensionStructure
            {
                Id = id,
                Name = name,
                Desc = desc,
                IsActive = isActive,
            };

            // Act
            Func<Task> action = async () =>
            {
                await sourceFormatBuilderService.SaveNewRootDimensionStructureHandlerAsync(dimensionStructure)
                   .ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<SourceFormatBuilderServiceException>()
               .WithInnerException<ValidationException>();
        }

        [Theory(Skip = "tmp")]
        [InlineData(1, "name", "desc", 1)]
        [InlineData(0, "", "desc", 1)]
        [InlineData(0, null, "desc", 1)]
        [InlineData(0, "na", "desc", 1)]
        [InlineData(0, "name", "", 1)]
        [InlineData(0, "name", null, 1)]
        [InlineData(0, "name", "de", 1)]
        [InlineData(0, "name", "desc", 2)]
        [SuppressMessage("ReSharper", "TooManyArguments")]
        public void ThrowException_WhenDimension_InputIsInvalid(
            long id,
            string name,
            string desc,
            int isActive)
        {
            // Arrange
            SourceFormatBuilderService sourceFormatBuilderService = new SourceFormatBuilderService(
                _masterDataWebApiClientMock.Object,
                _masterDataValidatorsMock.Object,
                _domainEntityHelperServiceMock.Object);

            Dimension dimension = new Dimension
            {
                Id = id,
                Name = name,
                Description = desc,
                IsActive = isActive,
            };

            DimensionStructure dimensionStructure = new DimensionStructure
            {
                Id = 100,
                Name = "name",
                Desc = "desc",
                IsActive = 1,
                Dimension = dimension,
                DimensionId = dimension.Id,
            };

            // Act
            Func<Task> action = async () =>
            {
                await sourceFormatBuilderService.SaveNewRootDimensionStructureHandlerAsync(dimensionStructure)
                   .ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<SourceFormatBuilderServiceException>()
               .WithInnerException<ValidationException>();
        }

        [Fact(Skip = "tmp")]
        public async Task AddDimensionStructureWithDimension_AsRootDimensionStructure()
        {
            // Arrange
            ISourceFormatBuilderService sourceFormatBuilderService = new SourceFormatBuilderService(
                _masterDataWebApiClientMock.Object,
                _masterDataValidatorsMock.Object,
                _domainEntityHelperServiceMock.Object);

            Dimension dimension = new Dimension
            {
                Id = 100,
                Name = "name",
                Description = "desc",
                IsActive = 1,
            };

            DimensionStructure dimensionStructure = new DimensionStructure
            {
                Id = 0,
                Name = "name",
                Desc = "desc",
                IsActive = 1,
                Dimension = dimension,
                DimensionId = dimension.Id,
            };

            // Act
            await sourceFormatBuilderService.SaveNewRootDimensionStructureHandlerAsync(dimensionStructure)
               .ConfigureAwait(false);

            // Assert
            sourceFormatBuilderService.SourceFormat.RootDimensionStructure.Id
               .Should().Be(dimensionStructure.Id);
            sourceFormatBuilderService.SourceFormat.RootDimensionStructure.Name
               .Should().Be(dimensionStructure.Name);
            sourceFormatBuilderService.SourceFormat.RootDimensionStructure.Desc
               .Should().Be(dimensionStructure.Desc);
            sourceFormatBuilderService.SourceFormat.RootDimensionStructure.IsActive
               .Should().Be(dimensionStructure.IsActive);
            sourceFormatBuilderService.SourceFormat.RootDimensionStructure.Id
               .Should().Be(dimensionStructure.Id);
        }

        [Fact(Skip = "tmp")]
        public async Task AddDimensionStructureWithoutDimension_AsRootDimensionStructure()
        {
            // Arrange
            ISourceFormatBuilderService sourceFormatBuilderService = new SourceFormatBuilderService(
                _masterDataWebApiClientMock.Object,
                _masterDataValidatorsMock.Object,
                _domainEntityHelperServiceMock.Object);

            DimensionStructure dimensionStructure = new DimensionStructure
            {
                Id = 0,
                Name = "name",
                Desc = "desc",
                IsActive = 1,
            };

            // Act
            await sourceFormatBuilderService.SaveNewRootDimensionStructureHandlerAsync(dimensionStructure)
               .ConfigureAwait(false);

            // Assert
            sourceFormatBuilderService.SourceFormat.RootDimensionStructure.Id
               .Should().Be(dimensionStructure.Id);
            sourceFormatBuilderService.SourceFormat.RootDimensionStructure.Name
               .Should().Be(dimensionStructure.Name);
            sourceFormatBuilderService.SourceFormat.RootDimensionStructure.Desc
               .Should().Be(dimensionStructure.Desc);
            sourceFormatBuilderService.SourceFormat.RootDimensionStructure.IsActive
               .Should().Be(dimensionStructure.IsActive);
        }

        [Fact]
        public void ThrowException_WhenInputIsNull()
        {
            // Arrange
            ISourceFormatBuilderService sourceFormatBuilderService = new SourceFormatBuilderService(
                _masterDataWebApiClientMock.Object,
                _masterDataValidatorsMock.Object,
                _domainEntityHelperServiceMock.Object);

            // Act
            Func<Task> action = async () =>
            {
                await sourceFormatBuilderService.SaveNewRootDimensionStructureHandlerAsync(
                        null)
                   .ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<SourceFormatBuilderServiceException>();
        }
    }
}