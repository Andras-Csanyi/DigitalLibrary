namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    using FluentAssertions;

    using Utils.Guards;

    using Xunit;

    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "CA1707")]
    [SuppressMessage("ReSharper", "CA1806")]
    [SuppressMessage("ReSharper", "ObjectCreationAsStatement")]
    public class Ctor_Validation_Should : TestBase
    {
        public Ctor_Validation_Should() : base(TestInfo)
        {
        }

        private const string TestInfo = nameof(Ctor_Validation_Should);

        [Fact]
        public void ThrowException_WhenCtorInputIsNull()
        {
            // Arrange

            // Act
            Action action = () => { new MasterDataBusinessLogic(null, null); };

            // Assert
            action.Should().ThrowExactly<GuardException>();
        }
    }
}