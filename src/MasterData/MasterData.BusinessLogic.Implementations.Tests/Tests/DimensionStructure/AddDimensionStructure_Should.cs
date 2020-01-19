using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

using FluentAssertions;

using Xunit;

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.Tests.DimensionStructure
{
    using Exceptions;

    [ExcludeFromCodeCoverage]
    public class AddDimensionStructure_Should : TestBase
    {
        public AddDimensionStructure_Should() : base(TestInfo)
        {
        }

        private const string TestInfo = nameof(AddDimensionStructure_Should);

        [Fact]
        public async Task Add_ToFirstLevel()
        {
            // Arrange
            DomainModel.DomainModel.Dimension topLevelDimension = new DomainModel.DomainModel.Dimension
            {
                Name = "top level dimension",
                Description = "top level dimension desc",
                IsActive = 1
            };
            DomainModel.DomainModel.Dimension topLevelDimensionResult = await masterDataBusinessLogic
               .AddDimensionAsync(topLevelDimension)
               .ConfigureAwait(false);

            DomainModel.DomainModel.DimensionStructure topLevelDimensionStructure =
                new DomainModel.DomainModel.DimensionStructure
                {
                    Name = "toplevel",
                    Desc = "toplevel desc",
                    IsActive = 1,
                    DimensionId = topLevelDimensionResult.Id,
                    ParentDimensionStructureId = 0
                };
            DomainModel.DomainModel.DimensionStructure topLeveldimensionStructureResult = await masterDataBusinessLogic
               .AddTopDimensionStructureAsync(
                    topLevelDimensionStructure)
               .ConfigureAwait(false);

            DomainModel.DomainModel.Dimension firstLevelDimension = new DomainModel.DomainModel.Dimension
            {
                Name = "first level dimension",
                Description = "first level dimension desc",
                IsActive = 1
            };
            DomainModel.DomainModel.Dimension firstLevelDimensionResult = await masterDataBusinessLogic
               .AddDimensionAsync(
                    firstLevelDimension).ConfigureAwait(false);

            DomainModel.DomainModel.DimensionStructure firstLevelDimensionStructure =
                new DomainModel.DomainModel.DimensionStructure
                {
                    Name = "first level",
                    Desc = "first level desc",
                    IsActive = 1,
                    DimensionId = firstLevelDimensionResult.Id,
                    ParentDimensionStructureId = topLeveldimensionStructureResult.Id,
                };

            // Act
            DomainModel.DomainModel.DimensionStructure firstLevelDimensionStructureResult =
                await masterDataBusinessLogic
                   .AddDimensionStructureAsync(firstLevelDimensionStructure)
                   .ConfigureAwait(false);

            // Assert
            firstLevelDimensionStructureResult.Should().NotBeNull();
            firstLevelDimensionStructureResult.Id.Should().NotBe(0);
            firstLevelDimensionStructureResult.Name.Should().Be(firstLevelDimensionStructure.Name);
            firstLevelDimensionStructureResult.Desc.Should().Be(firstLevelDimensionStructure.Desc);
            firstLevelDimensionStructureResult.DimensionId.Should().Be(firstLevelDimensionStructure.DimensionId);
            firstLevelDimensionStructureResult.Dimension.Id.Should().Be(firstLevelDimensionResult.Id);
            firstLevelDimensionStructureResult.Dimension.Name.Should().Be(firstLevelDimensionResult.Name);
            firstLevelDimensionStructureResult.Dimension.Description.Should().Be(firstLevelDimensionResult.Description);
            firstLevelDimensionStructureResult.ChildDimensionStructures.Count.Should().Be(0);

            // checking structure hierarchy
            DomainModel.DomainModel.DimensionStructure topLevelResult = await masterDataBusinessLogic
               .GetDimensionStructureById(
                    topLeveldimensionStructureResult.Id)
               .ConfigureAwait(false);

            topLevelResult.Id.Should().Be(topLeveldimensionStructureResult.Id);
            topLevelResult.Name.Should().Be(topLeveldimensionStructureResult.Name);
            topLevelResult.Desc.Should().Be(topLeveldimensionStructureResult.Desc);
            topLevelResult.IsActive.Should().Be(topLeveldimensionStructureResult.IsActive);
            topLevelResult.DimensionId.Should().Be(topLeveldimensionStructureResult.DimensionId);
            topLevelResult.Dimension.Id.Should().Be(topLeveldimensionStructureResult.DimensionId);
            topLevelResult.Dimension.Name.Should().Be(topLevelDimensionResult.Name);
            topLevelResult.Dimension.Description.Should().Be(topLevelDimensionResult.Description);
            topLevelResult.Dimension.IsActive.Should().Be(topLevelDimensionResult.IsActive);
            topLevelResult.ChildDimensionStructures.Count.Should().Be(1);

            topLevelResult.ChildDimensionStructures
               .FirstOrDefault(w => w.Id == firstLevelDimensionStructureResult.Id).Should().NotBeNull();
            DomainModel.DomainModel.DimensionStructure firstLevel = topLevelResult.ChildDimensionStructures
               .FirstOrDefault(w => w.Id == firstLevelDimensionStructureResult.Id);
            firstLevel.Id.Should().Be(firstLevelDimensionStructureResult.Id);
            firstLevel.Name.Should().Be(firstLevelDimensionStructureResult.Name);
            firstLevel.Desc.Should().Be(firstLevelDimensionStructureResult.Desc);
            firstLevel.IsActive.Should().Be(firstLevelDimensionStructureResult.IsActive);
            firstLevel.DimensionId.Should().Be(firstLevelDimensionStructureResult.DimensionId);
            firstLevel.ChildDimensionStructures.Should().BeEmpty();
        }

        [Fact]
        public async Task Add_ToFirstLevelAsSecond()
        {
            // Arrange
            DomainModel.DomainModel.Dimension topLevelDimension = new DomainModel.DomainModel.Dimension
            {
                Name = "top level dimension",
                Description = "top level dimension desc",
                IsActive = 1
            };
            DomainModel.DomainModel.Dimension topLevelDimensionResult = await masterDataBusinessLogic
               .AddDimensionAsync(topLevelDimension)
               .ConfigureAwait(false);

            DomainModel.DomainModel.DimensionStructure topLevelDimensionStructure =
                new DomainModel.DomainModel.DimensionStructure
                {
                    Name = "toplevel",
                    Desc = "toplevel desc",
                    IsActive = 1,
                    DimensionId = topLevelDimensionResult.Id,
                    ParentDimensionStructureId = 0
                };
            DomainModel.DomainModel.DimensionStructure topLeveldimensionStructureResult = await masterDataBusinessLogic
               .AddTopDimensionStructureAsync(
                    topLevelDimensionStructure)
               .ConfigureAwait(false);

            DomainModel.DomainModel.Dimension firstLevelDimension = new DomainModel.DomainModel.Dimension
            {
                Name = "first level dimension",
                Description = "first level dimension desc",
                IsActive = 1
            };
            DomainModel.DomainModel.Dimension firstLevelDimensionResult = await masterDataBusinessLogic
               .AddDimensionAsync(
                    firstLevelDimension).ConfigureAwait(false);

            DomainModel.DomainModel.DimensionStructure firstLevelDimensionStructure =
                new DomainModel.DomainModel.DimensionStructure
                {
                    Name = "first level",
                    Desc = "first level desc",
                    IsActive = 1,
                    DimensionId = firstLevelDimensionResult.Id,
                    ParentDimensionStructureId = topLeveldimensionStructureResult.Id,
                };

            DomainModel.DomainModel.DimensionStructure firstLevelDimensionStructureResult =
                await masterDataBusinessLogic
                   .AddDimensionStructureAsync(
                        firstLevelDimensionStructure)
                   .ConfigureAwait(false);


            DomainModel.DomainModel.Dimension firstLevelDimensionSecond = new DomainModel.DomainModel.Dimension
            {
                Name = "first level dimension - second",
                Description = "first level dimension - second - desc",
                IsActive = 1
            };
            DomainModel.DomainModel.Dimension firstLevelDimensionSecondResult = await masterDataBusinessLogic
               .AddDimensionAsync(
                    firstLevelDimensionSecond).ConfigureAwait(false);

            DomainModel.DomainModel.DimensionStructure firstLevelDimensionStructureSecond =
                new DomainModel.DomainModel.DimensionStructure
                {
                    Name = "first level - second",
                    Desc = "first level - second - desc",
                    IsActive = 1,
                    DimensionId = firstLevelDimensionSecondResult.Id,
                    ParentDimensionStructureId = topLeveldimensionStructureResult.Id,
                };

            // Act
            DomainModel.DomainModel.DimensionStructure firstLevelDimensionStructureSecondResult =
                await masterDataBusinessLogic
                   .AddDimensionStructureAsync(
                        firstLevelDimensionStructureSecond)
                   .ConfigureAwait(false);

            // Assert
            firstLevelDimensionStructureSecondResult.Should().NotBeNull();
            firstLevelDimensionStructureSecondResult.Id.Should().NotBe(0);
            firstLevelDimensionStructureSecondResult.Name
               .Should().Be(firstLevelDimensionStructureSecond.Name);
            firstLevelDimensionStructureSecondResult.Desc
               .Should().Be(firstLevelDimensionStructureSecond.Desc);
            firstLevelDimensionStructureSecondResult.DimensionId
               .Should().Be(firstLevelDimensionStructureSecond.DimensionId);
            firstLevelDimensionStructureSecondResult.Dimension.Id
               .Should().Be(firstLevelDimensionSecondResult.Id);
            firstLevelDimensionStructureSecondResult.Dimension.Name
               .Should().Be(firstLevelDimensionSecondResult.Name);
            firstLevelDimensionStructureSecondResult.Dimension.Description
               .Should().Be(firstLevelDimensionSecondResult.Description);
            firstLevelDimensionStructureSecondResult.ChildDimensionStructures.Count.Should().Be(0);

            // checking structure hierarchy
            DomainModel.DomainModel.DimensionStructure topLevelResult = await masterDataBusinessLogic
               .GetDimensionStructureById(
                    topLeveldimensionStructureResult.Id)
               .ConfigureAwait(false);

            topLevelResult.Id.Should().Be(topLeveldimensionStructureResult.Id);
            topLevelResult.Name.Should().Be(topLeveldimensionStructureResult.Name);
            topLevelResult.Desc.Should().Be(topLeveldimensionStructureResult.Desc);
            topLevelResult.IsActive.Should().Be(topLeveldimensionStructureResult.IsActive);
            topLevelResult.DimensionId.Should().Be(topLeveldimensionStructureResult.DimensionId);
            topLevelResult.Dimension.Id.Should().Be(topLeveldimensionStructureResult.DimensionId);
            topLevelResult.Dimension.Name.Should().Be(topLevelDimensionResult.Name);
            topLevelResult.Dimension.Description.Should().Be(topLevelDimensionResult.Description);
            topLevelResult.Dimension.IsActive.Should().Be(topLevelDimensionResult.IsActive);
            topLevelResult.ChildDimensionStructures.Count.Should().Be(2);

            topLevelResult.ChildDimensionStructures
               .FirstOrDefault(w => w.Id == firstLevelDimensionStructureResult.Id).Should().NotBeNull();
            DomainModel.DomainModel.DimensionStructure firstLevel = topLevelResult.ChildDimensionStructures
               .FirstOrDefault(w => w.Id == firstLevelDimensionStructureResult.Id);
            firstLevel.Id.Should().Be(firstLevelDimensionStructureResult.Id);
            firstLevel.Name.Should().Be(firstLevelDimensionStructureResult.Name);
            firstLevel.Desc.Should().Be(firstLevelDimensionStructureResult.Desc);
            firstLevel.IsActive.Should().Be(firstLevelDimensionStructureResult.IsActive);
            firstLevel.DimensionId.Should().Be(firstLevelDimensionStructureResult.DimensionId);
            firstLevel.ChildDimensionStructures.Should().BeEmpty();

            topLevelResult.ChildDimensionStructures
               .FirstOrDefault(w => w.Id == firstLevelDimensionStructureSecondResult.Id).Should().NotBeNull();
            DomainModel.DomainModel.DimensionStructure firstLevelSecond = topLevelResult.ChildDimensionStructures
               .FirstOrDefault(w => w.Id == firstLevelDimensionStructureSecondResult.Id);
            firstLevelSecond.Id.Should().Be(firstLevelDimensionStructureSecondResult.Id);
            firstLevelSecond.Name.Should().Be(firstLevelDimensionStructureSecondResult.Name);
            firstLevelSecond.Desc.Should().Be(firstLevelDimensionStructureSecondResult.Desc);
            firstLevelSecond.IsActive.Should().Be(firstLevelDimensionStructureSecondResult.IsActive);
            firstLevelSecond.DimensionId.Should().Be(firstLevelDimensionSecondResult.Id);
            firstLevelSecond.ChildDimensionStructures.Should().BeEmpty();
        }

        [Fact]
        public async Task Add_ToSecondLevel()
        {
            DomainModel.DomainModel.Dimension topLevelDimension = new DomainModel.DomainModel.Dimension
            {
                Name = "top level",
                Description = "top level desc",
                IsActive = 1
            };
            DomainModel.DomainModel.Dimension topLevelDimensionResult = await masterDataBusinessLogic
               .AddDimensionAsync(topLevelDimension)
               .ConfigureAwait(false);
            DomainModel.DomainModel.DimensionStructure topLevelDimensionStructure =
                new DomainModel.DomainModel.DimensionStructure
                {
                    Name = "top level dimension structure",
                    Desc = "top level dimension structure desc",
                    IsActive = 1,
                    DimensionId = topLevelDimensionResult.Id,
                    ParentDimensionStructureId = 0
                };
            DomainModel.DomainModel.DimensionStructure topLevelDimensionStructureResult = await masterDataBusinessLogic
               .AddTopDimensionStructureAsync(
                    topLevelDimensionStructure)
               .ConfigureAwait(false);

            DomainModel.DomainModel.Dimension firstLevelDimension = new DomainModel.DomainModel.Dimension
            {
                Name = "first level",
                Description = "first level desc",
                IsActive = 1
            };
            DomainModel.DomainModel.Dimension firstLevelDimensionResult = await masterDataBusinessLogic
               .AddDimensionAsync(firstLevelDimension)
               .ConfigureAwait(false);
            DomainModel.DomainModel.DimensionStructure firstLevelDimensionStructure =
                new DomainModel.DomainModel.DimensionStructure
                {
                    Name = "first level dimension structure",
                    Desc = "first level dimension structure desc",
                    IsActive = 1,
                    DimensionId = firstLevelDimensionResult.Id,
                    ParentDimensionStructureId = topLevelDimensionStructureResult.Id,
                };
            DomainModel.DomainModel.DimensionStructure firstLevelDimensionStructureResult =
                await masterDataBusinessLogic
                   .AddDimensionStructureAsync(
                        firstLevelDimensionStructure)
                   .ConfigureAwait(false);

            DomainModel.DomainModel.Dimension secondLevelDimension = new DomainModel.DomainModel.Dimension
            {
                Name = "second level",
                Description = "second level desc",
                IsActive = 1
            };
            DomainModel.DomainModel.Dimension secondLevelDimensionResult = await masterDataBusinessLogic
               .AddDimensionAsync(secondLevelDimension)
               .ConfigureAwait(false);
            DomainModel.DomainModel.DimensionStructure secondLevelDimensionStructure =
                new DomainModel.DomainModel.DimensionStructure
                {
                    Name = "second level dimension structure",
                    Desc = "second level dimension structure desc",
                    IsActive = 1,
                    DimensionId = secondLevelDimensionResult.Id,
                    ParentDimensionStructureId = firstLevelDimensionStructureResult.Id,
                };

            // Act
            DomainModel.DomainModel.DimensionStructure secondLevelDimensionStructureResult =
                await masterDataBusinessLogic
                   .AddDimensionStructureAsync(
                        secondLevelDimensionStructure)
                   .ConfigureAwait(false);

            // Assert
            secondLevelDimensionStructureResult.Should().NotBeNull();
            secondLevelDimensionStructureResult.Id.Should().NotBe(0);
            secondLevelDimensionStructureResult.Name.Should().Be(secondLevelDimensionStructure.Name);
            secondLevelDimensionStructureResult.Desc.Should().Be(secondLevelDimensionStructure.Desc);
            secondLevelDimensionStructureResult.DimensionId.Should().Be(secondLevelDimensionResult.Id);
            secondLevelDimensionStructureResult.Dimension.Id.Should().Be(secondLevelDimensionResult.Id);
            secondLevelDimensionStructureResult.Dimension.Name.Should().Be(secondLevelDimensionResult.Name);
            secondLevelDimensionStructureResult.Dimension.Description.Should()
               .Be(secondLevelDimensionResult.Description);

            // checking structure
            DomainModel.DomainModel.DimensionStructure hierarchy = await masterDataBusinessLogic
               .GetDimensionStructureById(
                    topLevelDimensionResult.Id)
               .ConfigureAwait(false);
            hierarchy.Id.Should().NotBe(0);
            hierarchy.Name.Should().Be(topLevelDimensionStructure.Name);
            hierarchy.Desc.Should().Be(topLevelDimensionStructure.Desc);
            hierarchy.ChildDimensionStructures.Count.Should().Be(1);
            hierarchy.DimensionId.Should().Be(topLevelDimensionResult.Id);
            hierarchy.Dimension.Id.Should().Be(topLevelDimensionResult.Id);
            hierarchy.Dimension.Name.Should().Be(topLevelDimensionResult.Name);
            hierarchy.Dimension.Description.Should().Be(topLevelDimensionResult.Description);

            DomainModel.DomainModel.DimensionStructure firstLevel = hierarchy.ChildDimensionStructures
               .FirstOrDefault(p => p.Name == firstLevelDimensionStructure.Name);
            firstLevel.Should().NotBeNull();
            firstLevel.Id.Should().NotBe(0);
            firstLevel.Name.Should().Be(firstLevelDimensionStructure.Name);
            firstLevel.Desc.Should().Be(firstLevelDimensionStructure.Desc);
            firstLevel.ChildDimensionStructures.Count.Should().Be(1);
            firstLevel.DimensionId.Should().Be(firstLevelDimensionResult.Id);


            DomainModel.DomainModel.DimensionStructure secondLevel = firstLevel.ChildDimensionStructures
               .FirstOrDefault(p => p.Name == secondLevelDimensionStructure.Name);
            secondLevel.Should().NotBeNull();
            secondLevel.Id.Should().NotBe(0);
            secondLevel.Name.Should().Be(secondLevelDimensionStructure.Name);
            secondLevel.Desc.Should().Be(secondLevelDimensionStructure.Desc);
            secondLevel.ChildDimensionStructures.Should().BeNullOrEmpty();
            secondLevel.DimensionId.Should().Be(secondLevelDimensionResult.Id);
        }

        [Fact]
        public async Task Add_ToSecondLevelAsSecond()
        {
            DomainModel.DomainModel.Dimension topLevelDimension = new DomainModel.DomainModel.Dimension
            {
                Name = "top level",
                Description = "top level desc",
                IsActive = 1
            };
            DomainModel.DomainModel.Dimension topLevelDimensionResult = await masterDataBusinessLogic
               .AddDimensionAsync(topLevelDimension)
               .ConfigureAwait(false);
            DomainModel.DomainModel.DimensionStructure topLevelDimensionStructure =
                new DomainModel.DomainModel.DimensionStructure
                {
                    Name = "top level dimension structure",
                    Desc = "top level dimension structure desc",
                    IsActive = 1,
                    DimensionId = topLevelDimensionResult.Id,
                    ParentDimensionStructureId = 0
                };
            DomainModel.DomainModel.DimensionStructure topLevelDimensionStructureResult = await masterDataBusinessLogic
               .AddTopDimensionStructureAsync(
                    topLevelDimensionStructure)
               .ConfigureAwait(false);

            DomainModel.DomainModel.Dimension firstLevelDimension = new DomainModel.DomainModel.Dimension
            {
                Name = "first level",
                Description = "first level desc",
                IsActive = 1
            };
            DomainModel.DomainModel.Dimension firstLevelDimensionResult = await masterDataBusinessLogic
               .AddDimensionAsync(firstLevelDimension)
               .ConfigureAwait(false);
            DomainModel.DomainModel.DimensionStructure firstLevelDimensionStructure =
                new DomainModel.DomainModel.DimensionStructure
                {
                    Name = "first level dimension structure",
                    Desc = "first level dimension structure desc",
                    IsActive = 1,
                    DimensionId = firstLevelDimensionResult.Id,
                    ParentDimensionStructureId = topLevelDimensionStructureResult.Id,
                };
            DomainModel.DomainModel.DimensionStructure firstLevelDimensionStructureResult =
                await masterDataBusinessLogic
                   .AddDimensionStructureAsync(
                        firstLevelDimensionStructure)
                   .ConfigureAwait(false);

            DomainModel.DomainModel.Dimension secondLevelDimension = new DomainModel.DomainModel.Dimension
            {
                Name = "second level",
                Description = "second level desc",
                IsActive = 1
            };
            DomainModel.DomainModel.Dimension secondLevelDimensionResult = await masterDataBusinessLogic
               .AddDimensionAsync(secondLevelDimension)
               .ConfigureAwait(false);
            DomainModel.DomainModel.DimensionStructure secondLevelDimensionStructure =
                new DomainModel.DomainModel.DimensionStructure
                {
                    Name = "second level dimension structure",
                    Desc = "second level dimension structure desc",
                    IsActive = 1,
                    DimensionId = secondLevelDimensionResult.Id,
                    ParentDimensionStructureId = firstLevelDimensionStructureResult.Id,
                };

            DomainModel.DomainModel.DimensionStructure secondLevelDimensionStructureResult =
                await masterDataBusinessLogic
                   .AddDimensionStructureAsync(
                        secondLevelDimensionStructure)
                   .ConfigureAwait(false);

            DomainModel.DomainModel.Dimension secondLevelDimensionSecond = new DomainModel.DomainModel.Dimension
            {
                Name = "second level - second",
                Description = "second level desc - second",
                IsActive = 1
            };
            DomainModel.DomainModel.Dimension secondLevelDimensionSecondResult = await masterDataBusinessLogic
               .AddDimensionAsync(secondLevelDimensionSecond)
               .ConfigureAwait(false);
            DomainModel.DomainModel.DimensionStructure secondLevelDimensionStructureSecond =
                new DomainModel.DomainModel.DimensionStructure
                {
                    Name = "second level dimension structure second",
                    Desc = "second level dimension structure second desc",
                    IsActive = 1,
                    DimensionId = secondLevelDimensionSecondResult.Id,
                    ParentDimensionStructureId = firstLevelDimensionStructureResult.Id,
                };

            // Act
            DomainModel.DomainModel.DimensionStructure secondLevelDimensionStructureSecondResult =
                await masterDataBusinessLogic
                   .AddDimensionStructureAsync(
                        secondLevelDimensionStructureSecond)
                   .ConfigureAwait(false);

            // Assert
            secondLevelDimensionStructureSecondResult.Should().NotBeNull();
            secondLevelDimensionStructureSecondResult.Id.Should().NotBe(0);
            secondLevelDimensionStructureSecondResult.Name
               .Should().Be(secondLevelDimensionStructureSecond.Name);
            secondLevelDimensionStructureSecondResult.Desc
               .Should().Be(secondLevelDimensionStructureSecond.Desc);
            secondLevelDimensionStructureSecondResult.DimensionId
               .Should().Be(secondLevelDimensionSecondResult.Id);
            secondLevelDimensionStructureSecondResult.Dimension.Id
               .Should().Be(secondLevelDimensionSecondResult.Id);
            secondLevelDimensionStructureSecondResult.Dimension.Name
               .Should().Be(secondLevelDimensionSecondResult.Name);
            secondLevelDimensionStructureSecondResult.Dimension.Description
               .Should().Be(secondLevelDimensionSecondResult.Description);

            // checking structure
            DomainModel.DomainModel.DimensionStructure hierarchy = await masterDataBusinessLogic
               .GetDimensionStructureById(
                    topLevelDimensionResult.Id)
               .ConfigureAwait(false);
            hierarchy.Id.Should().NotBe(0);
            hierarchy.Name.Should().Be(topLevelDimensionStructure.Name);
            hierarchy.Desc.Should().Be(topLevelDimensionStructure.Desc);
            hierarchy.ChildDimensionStructures.Count.Should().Be(1);
            hierarchy.DimensionId.Should().Be(topLevelDimensionResult.Id);
            hierarchy.Dimension.Id.Should().Be(topLevelDimensionResult.Id);
            hierarchy.Dimension.Name.Should().Be(topLevelDimensionResult.Name);
            hierarchy.Dimension.Description.Should().Be(topLevelDimensionResult.Description);

            DomainModel.DomainModel.DimensionStructure firstLevel = hierarchy.ChildDimensionStructures
               .FirstOrDefault(p => p.Name == firstLevelDimensionStructure.Name);
            firstLevel.Should().NotBeNull();
            firstLevel.Id.Should().NotBe(0);
            firstLevel.Name.Should().Be(firstLevelDimensionStructure.Name);
            firstLevel.Desc.Should().Be(firstLevelDimensionStructure.Desc);
            firstLevel.ChildDimensionStructures.Count.Should().Be(2);
            firstLevel.DimensionId.Should().Be(firstLevelDimensionResult.Id);

            DomainModel.DomainModel.DimensionStructure secondLevel = firstLevel.ChildDimensionStructures
               .FirstOrDefault(p => p.Name == secondLevelDimensionStructure.Name);
            secondLevel.Should().NotBeNull();
            secondLevel.Id.Should().NotBe(0);
            secondLevel.Name.Should().Be(secondLevelDimensionStructure.Name);
            secondLevel.Desc.Should().Be(secondLevelDimensionStructure.Desc);
            secondLevel.ChildDimensionStructures.Should().BeNullOrEmpty();
            secondLevel.DimensionId.Should().Be(secondLevelDimensionResult.Id);

            DomainModel.DomainModel.DimensionStructure secondLevelSecond = firstLevel.ChildDimensionStructures
               .FirstOrDefault(p => p.Name == secondLevelDimensionStructureSecond.Name);
            secondLevelSecond.Should().NotBeNull();
            secondLevelSecond.Id.Should().NotBe(0);
            secondLevelSecond.Name.Should().Be(secondLevelDimensionStructureSecond.Name);
            secondLevelSecond.Desc.Should().Be(secondLevelDimensionStructureSecond.Desc);
            secondLevelSecond.ChildDimensionStructures.Should().BeNullOrEmpty();
            secondLevelSecond.DimensionId.Should().Be(secondLevelDimensionSecondResult.Id);
        }

        [Fact]
        public async Task ThrowException_WhenThereIsNoParentDimensionStructure()
        {
            // Arrange
            DomainModel.DomainModel.Dimension topLevelDimension = new DomainModel.DomainModel.Dimension
            {
                Name = "top level dimension",
                Description = "top level dimension desc",
                IsActive = 1
            };
            DomainModel.DomainModel.Dimension topLevelDimensionResult = await masterDataBusinessLogic
               .AddDimensionAsync(topLevelDimension)
               .ConfigureAwait(false);

            DomainModel.DomainModel.DimensionStructure topLevelDimensionStructure =
                new DomainModel.DomainModel.DimensionStructure
                {
                    Name = "toplevel",
                    Desc = "toplevel desc",
                    IsActive = 1,
                    DimensionId = topLevelDimensionResult.Id,
                    ParentDimensionStructureId = 0
                };
            DomainModel.DomainModel.DimensionStructure topLeveldimensionStructureResult = await masterDataBusinessLogic
               .AddTopDimensionStructureAsync(
                    topLevelDimensionStructure)
               .ConfigureAwait(false);

            DomainModel.DomainModel.Dimension firstLevelDimension = new DomainModel.DomainModel.Dimension
            {
                Name = "first level dimension",
                Description = "first level dimension desc",
                IsActive = 1
            };
            DomainModel.DomainModel.Dimension firstLevelDimensionResult = await masterDataBusinessLogic
               .AddDimensionAsync(
                    firstLevelDimension).ConfigureAwait(false);

            DomainModel.DomainModel.DimensionStructure firstLevelDimensionStructure =
                new DomainModel.DomainModel.DimensionStructure
                {
                    Name = "first level",
                    Desc = "first level desc",
                    IsActive = 1,
                    DimensionId = firstLevelDimensionResult.Id,
                    ParentDimensionStructureId = 300
                };

            // Act
            Func<Task> action = async () =>
            {
                await masterDataBusinessLogic.AddDimensionStructureAsync(
                        firstLevelDimensionStructure)
                   .ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataBusinessLogicAddDimensionStructureAsyncOperationException>()
               .WithInnerException<MasterDataBusinessLogicNoSuchTopDimensionStructureEntity>();
        }
    }
}