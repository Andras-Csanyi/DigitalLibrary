using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

using DigitalLibrary.MasterData.Validators.TestData.TestData;

using FluentAssertions;

using FluentValidation;

using Xunit;

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.Tests.TopDimensionStructure
{
    using Exceptions;

    [ExcludeFromCodeCoverage]
    public class AddTopDimensionStructure_Validation_Should : TestBase
    {
        public AddTopDimensionStructure_Validation_Should() : base(TestInfo)
        {
        }

        private const string TestInfo = nameof(AddTopDimensionStructure_Validation_Should);

        [Theory]
        [MemberData(nameof(MasterData_DimensionStructure_TestData.AddTopDimensionStructure_Validation_TestData),
            MemberType = typeof(MasterData_DimensionStructure_TestData))]
        public async Task ThrowException_WhenInputIsInvalid(
            long id,
            string name,
            string desc,
            int isActive)
        {
            // Arrange
            DomainModel.DomainModel.DimensionStructure dimensionStructure =
                new DomainModel.DomainModel.DimensionStructure
                {
                    Id = id,
                    Name = name,
                    Desc = desc,
                    IsActive = isActive
                };

            // Act
            Func<Task> action = async () =>
            {
                await masterDataBusinessLogic.AddTopDimensionStructureAsync(
                    dimensionStructure).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataBusinessLogicAddTopDimensionStructureAsyncOperationException>()
               .WithInnerException<ValidationException>();
        }

        [Fact]
        public async Task ThrowException_WhenInputIsNull()
        {
            // Arrange

            // Act
            Func<Task> action = async () =>
            {
                await masterDataBusinessLogic.AddTopDimensionStructureAsync(null).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataBusinessLogicAddTopDimensionStructureAsyncOperationException>()
               .WithInnerException<MasterDataBusinessLogicArgumentNullException>();
        }
    }
}