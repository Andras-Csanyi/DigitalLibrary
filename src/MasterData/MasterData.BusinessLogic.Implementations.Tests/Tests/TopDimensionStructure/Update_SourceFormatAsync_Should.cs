namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.TopDimensionStructure
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DomainModel;

    using Exceptions;

    using FluentAssertions;

    using Validators.TestData;

    using Xunit;

    [ExcludeFromCodeCoverage]
    public class Update_SourceFormatAsync_Should : TestBase
    {
        public Update_SourceFormatAsync_Should() : base(TestInfo)
        {
        }

        private const string TestInfo = nameof(Update_SourceFormatAsync_Should);

        [Theory]
        [MemberData(
            nameof(MasterData_DimensionStructure_TestData.ModifyTopDimensionStructure_TestData),
            MemberType = typeof(MasterData_DimensionStructure_TestData))]
        public async Task Modify(
            string name,
            string desc,
            int isActive)
        {
            // Arrange
            SourceFormat orig = new SourceFormat
            {
                Name = "asdasd",
                Desc = "asdasd",
                IsActive = 1,
            };

            SourceFormat origRes = await masterDataBusinessLogic.AddSourceFormatAsync(
                orig).ConfigureAwait(false);

            SourceFormat mod = new SourceFormat
            {
                Id = origRes.Id,
                Name = name,
                Desc = desc,
                IsActive = isActive,
            };

            // Act
            SourceFormat res = await masterDataBusinessLogic.UpdateSourceFormatAsync(mod)
               .ConfigureAwait(false);

            // Assert
            res.Should().NotBeNull();
            res.Id.Should().Be(origRes.Id);
            res.Name.Should().Be(name);
            res.Desc.Should().Be(desc);
            res.IsActive.Should().Be(isActive);
        }

        [Fact]
        public async Task ThrowException_WhenThereIsNoSuchSourceFormat()
        {
            // Arrange
            SourceFormat sourceFormat = new SourceFormat
            {
                Id = 100,
                Name = "asdasd",
                Desc = "asdasd",
                IsActive = 1,
            };

            // Act
            Func<Task> action = async () =>
            {
                await masterDataBusinessLogic.UpdateSourceFormatAsync(sourceFormat)
                   .ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataBusinessLogicUpdateSourceFormatAsyncOperationException>()
               .WithInnerException<MasterDataBusinessLogicNoSuchSourceFormatEntityException>();
        }
    }
}