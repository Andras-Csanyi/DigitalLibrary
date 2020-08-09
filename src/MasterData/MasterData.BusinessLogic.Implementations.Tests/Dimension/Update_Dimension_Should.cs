namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.Dimension
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DomainModel;

    using Exceptions;

    using FluentAssertions;

    using Utils.Guards;

    using Xunit;

    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "CA1707")]
    [SuppressMessage("ReSharper", "UnusedVariable")]
    public class Update_Dimension_Should : TestBase
    {
        public Update_Dimension_Should() : base(TestInfo)
        {
        }

        private const string TestInfo = nameof(Update_Dimension_Should);

        [Fact]
        public async Task Modify_The_Dimension()
        {
            // Arrange
            string name = "name name";
            string desc = "desc desc";
            int isActive = 0;

            Dimension dimension = new Dimension
            {
                Name = "name",
                Description = "desc",
                IsActive = 0
            };
            Dimension dimensionResult = await masterDataBusinessLogic.AddDimensionAsync(dimension)
               .ConfigureAwait(false);

            dimensionResult.Name = name;
            dimensionResult.Description = desc;
            dimensionResult.IsActive = isActive;
            // Act
            Dimension result = await masterDataBusinessLogic
               .UpdateDimensionAsync(dimensionResult)
               .ConfigureAwait(false);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(dimensionResult.Id);
            result.Name.Should().Be(dimensionResult.Name);
            result.Description.Should().Be(dimensionResult.Description);
            result.IsActive.Should().Be(dimensionResult.IsActive);
        }

        [Fact]
        public void ThrowException_WhenThereIsNoSuchEntity()
        {
            // Arrange
            Dimension dimension = new Dimension
            {
                Id = 299,
                Name = "name",
                Description = "desc",
                IsActive = 0
            };

            // Act
            Func<Task> action = async () =>
            {
                Dimension result = await masterDataBusinessLogic
                   .UpdateDimensionAsync(dimension)
                   .ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataBusinessLogicUpdateDimensionAsyncOperationException>()
               .WithInnerException<GuardException>();
        }
    }
}