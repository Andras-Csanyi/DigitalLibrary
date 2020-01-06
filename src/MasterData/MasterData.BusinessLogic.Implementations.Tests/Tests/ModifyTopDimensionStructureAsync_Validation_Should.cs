namespace DigitalLibrary.IaC.MasterData.BusinessLogic.Implementations.Tests.Tests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DomainModel.DomainModel;

    using Exceptions.Exceptions;

    using FluentAssertions;

    using FluentValidation;

    using Validators.TestData.TestData;

    using Xunit;

    [ExcludeFromCodeCoverage]
    public class ModifyTopDimensionStructureAsync_Validation_Should : TestBase
    {
        public ModifyTopDimensionStructureAsync_Validation_Should() : base(TestInfo)
        {
        }

        private const string TestInfo =
            nameof(ModifyTopDimensionStructureAsync_Validation_Should);

        [Theory]
        [MemberData(nameof(MasterData_DimensionStructure_TestData.ModifyTopDimensionStructure_Validation_TestData),
            MemberType = typeof(MasterData_DimensionStructure_TestData))]
        public async Task ThrowException_WhenInputIsInvalid(
            long id,
            string name,
            string desc,
            int isActive)
        {
            // Arrange
            DimensionStructure dimensionStructure = new DimensionStructure
            {
                Id = id,
                ParentDimensionStructureId = null,
                Name = name,
                Desc = desc,
                IsActive = isActive
            };

            // Act
            Func<Task> action = async () =>
            {
                await masterDataBusinessLogic.UpdateTopDimensionStructureAsync(
                    dimensionStructure).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataBusinessLogicUpdateTopDimensionStructureAsyncOperationException>()
                .WithInnerException<ValidationException>();
        }

        [Fact]
        public async Task ThrowException_WhenInputIsNull()
        {
            // Arrange

            // Act
            Func<Task> action = async () =>
            {
                await masterDataBusinessLogic.UpdateTopDimensionStructureAsync(
                        null)
                    .ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataBusinessLogicUpdateTopDimensionStructureAsyncOperationException>()
                .WithInnerException<MasterDataBusinessLogicArgumentNullException>();
        }
    }
}