namespace DigitalLibrary.IaC.MasterData.BusinessLogic.Implementations.Tests.Tests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using Exceptions.Exceptions;

    using FluentAssertions;

    using Implementations;

    using Xunit;

    [ExcludeFromCodeCoverage]
    public class Ctor_Validation_Should : TestBase
    {
        public Ctor_Validation_Should() : base(TestInfo)
        {
        }

        public const string TestInfo = nameof(Ctor_Validation_Should);

        [Fact]
        public async Task Throw_MasterDataBusinessLogicArgumentNullException_WhenCtorInputIsNull()
        {
            // Arrange

            // Act
            Func<Task> action = async () => { new MasterDataBusinessLogic(null, null); };

            // Assert
            action.Should().ThrowExactly<MasterDataBusinessLogicArgumentNullException>();
        }
    }
}