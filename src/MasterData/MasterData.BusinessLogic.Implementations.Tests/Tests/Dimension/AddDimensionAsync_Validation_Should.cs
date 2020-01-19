using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

using DigitalLibrary.MasterData.Validators.TestData.TestData;

using FluentAssertions;

using FluentValidation;

using Xunit;

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.Tests.Dimension
{
    using Exceptions;

    [ExcludeFromCodeCoverage]
    public class AddDimensionAsync_Validation_Should : TestBase
    {
        public AddDimensionAsync_Validation_Should() : base(TestInfo)
        {
        }

        private const string TestInfo = nameof(AddDimensionAsync_Validation_Should);

        [Theory]
        [MemberData(
            nameof(MasterData_Dimension_TestData.AddDimensionAsync_Validation),
            MemberType = typeof(MasterData_Dimension_TestData))]
        public async Task Throw_MasterDataBUsinessLogicAddDimensionAsyncOperationException_WhenInputIsInvalid(
            long id,
            string name,
            string desc,
            int isActive)
        {
            // Arrange
            DomainModel.DomainModel.Dimension dimension = new DomainModel.DomainModel.Dimension
            {
                Id = id,
                Name = name,
                Description = desc,
                IsActive = isActive
            };

            // Act
            Func<Task> action = async () =>
            {
                await masterDataBusinessLogic.AddDimensionAsync(dimension).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataBusinessLogicAddDimensionAsyncOperationException>()
               .WithInnerException<ValidationException>();
        }

        [Fact]
        public async Task Throw_MasterDataBusinessLogicArgumentNullException()
        {
            // Arrange

            // Act
            Func<Task> action = async () =>
            {
                await masterDataBusinessLogic.AddDimensionAsync(null).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataBusinessLogicAddDimensionAsyncOperationException>()
               .WithInnerException<MasterDataBusinessLogicArgumentNullException>();
        }
    }
}