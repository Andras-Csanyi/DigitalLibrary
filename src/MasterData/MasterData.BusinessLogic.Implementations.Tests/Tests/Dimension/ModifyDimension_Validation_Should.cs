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
    public class ModifyDimension_Validation_Should : TestBase
    {
        private const string TestInfo = nameof(ModifyDimension_Validation_Should);

        public ModifyDimension_Validation_Should() : base(TestInfo)
        {
        }

        [Theory]
        [MemberData(nameof(MasterData_Dimension_TestData.ModifyDimensionAsync_InputValidation),
            MemberType = typeof(MasterData_Dimension_TestData))]
        public async Task ThrowException_WhenInputsAreNull(
            long id,
            DomainModel.DomainModel.Dimension dimension)
        {
            // Arrange

            // Act
            Func<Task> action = async () => { await masterDataBusinessLogic.ModifyDimensionAsync(id, dimension); };

            // Assert
            action.Should().ThrowExactly<MasterDataBusinessLogicModifyDimensionAsyncOperationException>()
               .WithInnerException<MasterDataBusinessLogicArgumentNullException>();
        }

        [Theory]
        [MemberData(nameof(MasterData_Dimension_TestData.ModifyDimensionAsync_Validation),
            MemberType = typeof(MasterData_Dimension_TestData))]
        public async Task ThrowException_WhenInputIsInvalid(
            long id,
            string name,
            string desc,
            int isActive)
        {
            // Arrange
            DomainModel.DomainModel.Dimension dimension = new DomainModel.DomainModel.Dimension
            {
                Name = name,
                Description = desc,
                IsActive = isActive
            };

            // Act
            Func<Task> action = async () =>
            {
                await masterDataBusinessLogic.ModifyDimensionAsync(id, dimension).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataBusinessLogicModifyDimensionAsyncOperationException>()
               .WithInnerException<ValidationException>();
        }
    }
}