namespace DigitalLibrary.IaC.MasterData.BusinessLogic.Implementations.Tests.Tests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Threading.Tasks;

    using DomainModel.DomainModel;

    using Exceptions.Exceptions;

    using FluentAssertions;

    using Xunit;

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
            Dimension topLevelDimension = new Dimension
            {
                Name = "top level dimension",
                Description = "top level dimension desc",
                IsActive = 1
            };
            Dimension topLevelDimensionResult = await masterDataBusinessLogic.AddDimensionAsync(topLevelDimension)
                .ConfigureAwait(false);

            DimensionStructure topLevelDimensionStructure = new DimensionStructure
            {
                Name = "toplevel",
                Desc = "toplevel desc",
                IsActive = 1,
                DimensionId = topLevelDimensionResult.Id,
                ParentDimensionStructureId = 0
            };
            DimensionStructure topLeveldimensionStructureResult = await masterDataBusinessLogic
                .AddTopDimensionStructureAsync(
                    topLevelDimensionStructure)
                .ConfigureAwait(false);

            Dimension firstLevelDimension = new Dimension
            {
                Name = "first level dimension",
                Description = "first level dimension desc",
                IsActive = 1
            };
            Dimension firstLevelDimensionResult = await masterDataBusinessLogic.AddDimensionAsync(
                firstLevelDimension).ConfigureAwait(false);

            DimensionStructure firstLevelDimensionStructure = new DimensionStructure
            {
                Name = "first level",
                Desc = "first level desc",
                IsActive = 1,
                DimensionId = firstLevelDimensionResult.Id,
                ParentDimensionStructureId = topLeveldimensionStructureResult.Id,
            };

            // Act
            DimensionStructure firstLevelDimensionStructureResult = await masterDataBusinessLogic
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
            DimensionStructure topLevelResult = await masterDataBusinessLogic.GetDimensionStructureById(
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
            DimensionStructure firstLevel = topLevelResult.ChildDimensionStructures
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
            Dimension topLevelDimension = new Dimension
            {
                Name = "top level dimension",
                Description = "top level dimension desc",
                IsActive = 1
            };
            Dimension topLevelDimensionResult = await masterDataBusinessLogic.AddDimensionAsync(topLevelDimension)
                .ConfigureAwait(false);

            DimensionStructure topLevelDimensionStructure = new DimensionStructure
            {
                Name = "toplevel",
                Desc = "toplevel desc",
                IsActive = 1,
                DimensionId = topLevelDimensionResult.Id,
                ParentDimensionStructureId = 0
            };
            DimensionStructure topLeveldimensionStructureResult = await masterDataBusinessLogic
                .AddTopDimensionStructureAsync(
                    topLevelDimensionStructure)
                .ConfigureAwait(false);

            Dimension firstLevelDimension = new Dimension
            {
                Name = "first level dimension",
                Description = "first level dimension desc",
                IsActive = 1
            };
            Dimension firstLevelDimensionResult = await masterDataBusinessLogic.AddDimensionAsync(
                firstLevelDimension).ConfigureAwait(false);

            DimensionStructure firstLevelDimensionStructure = new DimensionStructure
            {
                Name = "first level",
                Desc = "first level desc",
                IsActive = 1,
                DimensionId = firstLevelDimensionResult.Id,
                ParentDimensionStructureId = topLeveldimensionStructureResult.Id,
            };

            DimensionStructure firstLevelDimensionStructureResult = await masterDataBusinessLogic
                .AddDimensionStructureAsync(
                    firstLevelDimensionStructure)
                .ConfigureAwait(false);


            Dimension firstLevelDimensionSecond = new Dimension
            {
                Name = "first level dimension - second",
                Description = "first level dimension - second - desc",
                IsActive = 1
            };
            Dimension firstLevelDimensionSecondResult = await masterDataBusinessLogic.AddDimensionAsync(
                firstLevelDimensionSecond).ConfigureAwait(false);

            DimensionStructure firstLevelDimensionStructureSecond = new DimensionStructure
            {
                Name = "first level - second",
                Desc = "first level - second - desc",
                IsActive = 1,
                DimensionId = firstLevelDimensionSecondResult.Id,
                ParentDimensionStructureId = topLeveldimensionStructureResult.Id,
            };

            // Act
            DimensionStructure firstLevelDimensionStructureSecondResult = await masterDataBusinessLogic
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
            DimensionStructure topLevelResult = await masterDataBusinessLogic.GetDimensionStructureById(
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
            DimensionStructure firstLevel = topLevelResult.ChildDimensionStructures
                .FirstOrDefault(w => w.Id == firstLevelDimensionStructureResult.Id);
            firstLevel.Id.Should().Be(firstLevelDimensionStructureResult.Id);
            firstLevel.Name.Should().Be(firstLevelDimensionStructureResult.Name);
            firstLevel.Desc.Should().Be(firstLevelDimensionStructureResult.Desc);
            firstLevel.IsActive.Should().Be(firstLevelDimensionStructureResult.IsActive);
            firstLevel.DimensionId.Should().Be(firstLevelDimensionStructureResult.DimensionId);
            firstLevel.ChildDimensionStructures.Should().BeEmpty();

            topLevelResult.ChildDimensionStructures
                .FirstOrDefault(w => w.Id == firstLevelDimensionStructureSecondResult.Id).Should().NotBeNull();
            DimensionStructure firstLevelSecond = topLevelResult.ChildDimensionStructures
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
            Dimension topLevelDimension = new Dimension
            {
                Name = "top level",
                Description = "top level desc",
                IsActive = 1
            };
            Dimension topLevelDimensionResult = await masterDataBusinessLogic.AddDimensionAsync(topLevelDimension)
                .ConfigureAwait(false);
            DimensionStructure topLevelDimensionStructure = new DimensionStructure
            {
                Name = "top level dimension structure",
                Desc = "top level dimension structure desc",
                IsActive = 1,
                DimensionId = topLevelDimensionResult.Id,
                ParentDimensionStructureId = 0
            };
            DimensionStructure topLevelDimensionStructureResult = await masterDataBusinessLogic
                .AddTopDimensionStructureAsync(
                    topLevelDimensionStructure)
                .ConfigureAwait(false);

            Dimension firstLevelDimension = new Dimension
            {
                Name = "first level",
                Description = "first level desc",
                IsActive = 1
            };
            Dimension firstLevelDimensionResult = await masterDataBusinessLogic.AddDimensionAsync(firstLevelDimension)
                .ConfigureAwait(false);
            DimensionStructure firstLevelDimensionStructure = new DimensionStructure
            {
                Name = "first level dimension structure",
                Desc = "first level dimension structure desc",
                IsActive = 1,
                DimensionId = firstLevelDimensionResult.Id,
                ParentDimensionStructureId = topLevelDimensionStructureResult.Id,
            };
            DimensionStructure firstLevelDimensionStructureResult = await masterDataBusinessLogic
                .AddDimensionStructureAsync(
                    firstLevelDimensionStructure)
                .ConfigureAwait(false);

            Dimension secondLevelDimension = new Dimension
            {
                Name = "second level",
                Description = "second level desc",
                IsActive = 1
            };
            Dimension secondLevelDimensionResult = await masterDataBusinessLogic.AddDimensionAsync(secondLevelDimension)
                .ConfigureAwait(false);
            DimensionStructure secondLevelDimensionStructure = new DimensionStructure
            {
                Name = "second level dimension structure",
                Desc = "second level dimension structure desc",
                IsActive = 1,
                DimensionId = secondLevelDimensionResult.Id,
                ParentDimensionStructureId = firstLevelDimensionStructureResult.Id,
            };

            // Act
            DimensionStructure secondLevelDimensionStructureResult = await masterDataBusinessLogic
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
            DimensionStructure hierarchy = await masterDataBusinessLogic.GetDimensionStructureById(
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

            DimensionStructure firstLevel = hierarchy.ChildDimensionStructures
                .FirstOrDefault(p => p.Name == firstLevelDimensionStructure.Name);
            firstLevel.Should().NotBeNull();
            firstLevel.Id.Should().NotBe(0);
            firstLevel.Name.Should().Be(firstLevelDimensionStructure.Name);
            firstLevel.Desc.Should().Be(firstLevelDimensionStructure.Desc);
            firstLevel.ChildDimensionStructures.Count.Should().Be(1);
            firstLevel.DimensionId.Should().Be(firstLevelDimensionResult.Id);


            DimensionStructure secondLevel = firstLevel.ChildDimensionStructures
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
            Dimension topLevelDimension = new Dimension
            {
                Name = "top level",
                Description = "top level desc",
                IsActive = 1
            };
            Dimension topLevelDimensionResult = await masterDataBusinessLogic.AddDimensionAsync(topLevelDimension)
                .ConfigureAwait(false);
            DimensionStructure topLevelDimensionStructure = new DimensionStructure
            {
                Name = "top level dimension structure",
                Desc = "top level dimension structure desc",
                IsActive = 1,
                DimensionId = topLevelDimensionResult.Id,
                ParentDimensionStructureId = 0
            };
            DimensionStructure topLevelDimensionStructureResult = await masterDataBusinessLogic
                .AddTopDimensionStructureAsync(
                    topLevelDimensionStructure)
                .ConfigureAwait(false);

            Dimension firstLevelDimension = new Dimension
            {
                Name = "first level",
                Description = "first level desc",
                IsActive = 1
            };
            Dimension firstLevelDimensionResult = await masterDataBusinessLogic.AddDimensionAsync(firstLevelDimension)
                .ConfigureAwait(false);
            DimensionStructure firstLevelDimensionStructure = new DimensionStructure
            {
                Name = "first level dimension structure",
                Desc = "first level dimension structure desc",
                IsActive = 1,
                DimensionId = firstLevelDimensionResult.Id,
                ParentDimensionStructureId = topLevelDimensionStructureResult.Id,
            };
            DimensionStructure firstLevelDimensionStructureResult = await masterDataBusinessLogic
                .AddDimensionStructureAsync(
                    firstLevelDimensionStructure)
                .ConfigureAwait(false);

            Dimension secondLevelDimension = new Dimension
            {
                Name = "second level",
                Description = "second level desc",
                IsActive = 1
            };
            Dimension secondLevelDimensionResult = await masterDataBusinessLogic.AddDimensionAsync(secondLevelDimension)
                .ConfigureAwait(false);
            DimensionStructure secondLevelDimensionStructure = new DimensionStructure
            {
                Name = "second level dimension structure",
                Desc = "second level dimension structure desc",
                IsActive = 1,
                DimensionId = secondLevelDimensionResult.Id,
                ParentDimensionStructureId = firstLevelDimensionStructureResult.Id,
            };

            DimensionStructure secondLevelDimensionStructureResult = await masterDataBusinessLogic
                .AddDimensionStructureAsync(
                    secondLevelDimensionStructure)
                .ConfigureAwait(false);

            Dimension secondLevelDimensionSecond = new Dimension
            {
                Name = "second level - second",
                Description = "second level desc - second",
                IsActive = 1
            };
            Dimension secondLevelDimensionSecondResult = await masterDataBusinessLogic
                .AddDimensionAsync(secondLevelDimensionSecond)
                .ConfigureAwait(false);
            DimensionStructure secondLevelDimensionStructureSecond = new DimensionStructure
            {
                Name = "second level dimension structure second",
                Desc = "second level dimension structure second desc",
                IsActive = 1,
                DimensionId = secondLevelDimensionSecondResult.Id,
                ParentDimensionStructureId = firstLevelDimensionStructureResult.Id,
            };

            // Act
            DimensionStructure secondLevelDimensionStructureSecondResult = await masterDataBusinessLogic
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
            DimensionStructure hierarchy = await masterDataBusinessLogic.GetDimensionStructureById(
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

            DimensionStructure firstLevel = hierarchy.ChildDimensionStructures
                .FirstOrDefault(p => p.Name == firstLevelDimensionStructure.Name);
            firstLevel.Should().NotBeNull();
            firstLevel.Id.Should().NotBe(0);
            firstLevel.Name.Should().Be(firstLevelDimensionStructure.Name);
            firstLevel.Desc.Should().Be(firstLevelDimensionStructure.Desc);
            firstLevel.ChildDimensionStructures.Count.Should().Be(2);
            firstLevel.DimensionId.Should().Be(firstLevelDimensionResult.Id);

            DimensionStructure secondLevel = firstLevel.ChildDimensionStructures
                .FirstOrDefault(p => p.Name == secondLevelDimensionStructure.Name);
            secondLevel.Should().NotBeNull();
            secondLevel.Id.Should().NotBe(0);
            secondLevel.Name.Should().Be(secondLevelDimensionStructure.Name);
            secondLevel.Desc.Should().Be(secondLevelDimensionStructure.Desc);
            secondLevel.ChildDimensionStructures.Should().BeNullOrEmpty();
            secondLevel.DimensionId.Should().Be(secondLevelDimensionResult.Id);

            DimensionStructure secondLevelSecond = firstLevel.ChildDimensionStructures
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
            Dimension topLevelDimension = new Dimension
            {
                Name = "top level dimension",
                Description = "top level dimension desc",
                IsActive = 1
            };
            Dimension topLevelDimensionResult = await masterDataBusinessLogic.AddDimensionAsync(topLevelDimension)
                .ConfigureAwait(false);

            DimensionStructure topLevelDimensionStructure = new DimensionStructure
            {
                Name = "toplevel",
                Desc = "toplevel desc",
                IsActive = 1,
                DimensionId = topLevelDimensionResult.Id,
                ParentDimensionStructureId = 0
            };
            DimensionStructure topLeveldimensionStructureResult = await masterDataBusinessLogic
                .AddTopDimensionStructureAsync(
                    topLevelDimensionStructure)
                .ConfigureAwait(false);

            Dimension firstLevelDimension = new Dimension
            {
                Name = "first level dimension",
                Description = "first level dimension desc",
                IsActive = 1
            };
            Dimension firstLevelDimensionResult = await masterDataBusinessLogic.AddDimensionAsync(
                firstLevelDimension).ConfigureAwait(false);

            DimensionStructure firstLevelDimensionStructure = new DimensionStructure
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