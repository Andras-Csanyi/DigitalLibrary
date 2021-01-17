namespace Guard.Tests
{
    using System;

    using DigitalLibrary.Utils.Guards;

    using FluentAssertions;

    using Xunit;

    public class StringGuardShould
    {
        [Fact]
        public void ThrowExceptionWhenStringIsEmpty()
        {
            // Arrange
            string empty = string.Empty;

            // Act
            Action action = () => { Check.NotNullOrEmptyOrWhitespace(empty); };

            // Assert
            action.Should().ThrowExactly<GuardException>();
        }

        [Fact]
        public void ThrowExceptionWhenStringIsWhitespace()
        {
            // Arrange
            string whiteSpace = " ";

            // Act
            Action action = () => { Check.NotNullOrEmptyOrWhitespace(whiteSpace); };

            // Assert
            action.Should().ThrowExactly<GuardException>();
        }

        [Fact]
        public void ThrowExceptionWhenStringIsNull()
        {
            // Arrange
            string nullString = null;

            // Act
            Action action = () => { Check.NotNullOrEmptyOrWhitespace(nullString); };

            // Assert
            action.Should().ThrowExactly<GuardException>();
        }
    }
}