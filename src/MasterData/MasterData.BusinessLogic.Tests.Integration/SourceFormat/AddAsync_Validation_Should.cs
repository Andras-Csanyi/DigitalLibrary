namespace DigitalLibrary.MasterData.BusinessLogic.Tests.Integration.SourceFormat
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.Implementations.SourceFormat;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.Tests.TestData.SourceFormat;

    using FluentAssertions;

    using Xunit;
    using Xunit.Abstractions;

    [ExcludeFromCodeCoverage]
    public class AddAsync_Validation_Should : TestBase
    {
        [Fact]
        public async Task Throw_WhenInputIsNull()
        {
            // Arrange

            // Action
            Func<Task> task = async () =>
            {
                await _masterDataBusinessLogic
                   .MasterDataSourceFormatBusinessLogic
                   .AddAsync(null)
                   .ConfigureAwait(false);
            };

            // Assert
            task.Should().ThrowExactly<MasterDataBusinessLogicSourceFormatDatabaseOperationException>();
        }

        [Theory]
        [ClassData(typeof(Create_Validation_TestData))]
        public async Task Throw_WhenInputIsInvalid(
            long id,
            string name,
            string desc,
            int isActive)
        {
            // Arrange
            SourceFormat sourceFormat = new SourceFormat
            {
                Id = id,
                Name = name,
                Desc = desc,
                IsActive = isActive,
            };

            // Action
            Func<Task> task = async () =>
            {
                await _masterDataBusinessLogic
                   .MasterDataSourceFormatBusinessLogic
                   .AddAsync(sourceFormat)
                   .ConfigureAwait(false);
            };

            // Assert
            task.Should().ThrowExactly<MasterDataBusinessLogicSourceFormatDatabaseOperationException>();
        }

        public AddAsync_Validation_Should(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
        }
    }
}
