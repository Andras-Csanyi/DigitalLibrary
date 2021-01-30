namespace Guard.Tests
{
    using System;

    using DigitalLibrary.Utils.Guards;

    using FluentAssertions;

    using Xunit;

    public class IntsAreNotEqualShould
    {
        [Fact]
        public void ThrowExceptionWhenValuesAreEqual()
        {
            // Arrange
            int hundred = 100;

            // Act
            Action action = () => { Check.AreNotEqual(hundred, hundred); };

            // Assert
            action.Should().ThrowExactly<GuardException>();
        }
    }
}