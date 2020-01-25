namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using Exceptions;

    using FluentAssertions;

    using Utils.Guards;

    using Xunit;

    [ExcludeFromCodeCoverage]
    public class Ctor_Validation_Should : TestBase
    {
        public Ctor_Validation_Should() : base(TestInfo)
        {
        }

        public const string TestInfo = nameof(Ctor_Validation_Should);

        [Fact]
        public async Task ThrowException_WhenCtorInputIsNull()
        {
            // Arrange

            // Act
            Func<Task> action = async () => { new MasterDataBusinessLogic(null, null); };

            // Assert
            action.Should().ThrowExactly<GuardException>();
        }
    }
}