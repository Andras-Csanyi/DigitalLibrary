namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.DimensionStructure
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DomainModel.DomainModel;

    using Exceptions;

    using FluentAssertions;

    using FluentValidation;

    using Validators.TestData.TestData;

    using Xunit;

    [ExcludeFromCodeCoverage]
    public class UpdateDimensionStructureAsync_Validation_Should : TestBase
    {
        private const string TestInfo = nameof(UpdateDimensionStructureAsync_Validation_Should);

        public UpdateDimensionStructureAsync_Validation_Should() : base(TestInfo)
        {
        }

        [Fact]
        public async Task ThrowException_WhenInputIsNull()
        {
            // Arrange

            // Act
            Func<Task> action = async () =>
            {
                await masterDataBusinessLogic.UpdateDimensionStructureAsync(null).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataBusinessLogicUpdateDimensionAsyncOperationException>()
               .WithInnerException<ArgumentNullException>();
        }

        [Theory]
        [MemberData(nameof(MasterData_DimensionStructure_TestData.ModifyDimensionStructure_Validation_TestData),
            MemberType = typeof(MasterData_DimensionStructure_TestData))]
        public async Task ThrowException_WhenInputIsInvalid(
            long id,
            string name,
            string desc,
            int isActive,
            long parentDimensionStructureId)
        {
            // Arrange
            DimensionStructure dimensionStructure = new DimensionStructure
            {
                Id = id,
                Name = name,
                Desc = desc,
                IsActive = isActive,
                ParentDimensionStructureId = parentDimensionStructureId,
            };

            // Act
            Func<Task> action = async () =>
            {
                await masterDataBusinessLogic.UpdateDimensionStructureAsync(dimensionStructure)
                   .ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataBusinessLogicUpdateDimensionAsyncOperationException>()
               .WithInnerException<ValidationException>();
        }
    }
}