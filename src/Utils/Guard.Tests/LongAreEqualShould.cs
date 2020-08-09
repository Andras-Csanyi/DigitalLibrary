namespace Guard.Tests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DigitalLibrary.Utils.Guards;

    using FluentAssertions;

    using Xunit;

    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "CA1707")]
    public class LongAreEqualShould
    {
        [Fact]
        public void NotThrowException_WhenValuesArentEqual()
        {
            // Arrange
            long value = 100;
            long comparedTo = 99;

            // Act
            Action action = () => { Check.AreNotEqual(value, comparedTo); };

            // Assert
            action.Should().NotThrow();
        }

        [Fact]
        public void ThrowException_WhenAreEqual()
        {
            // Arrange
            long value = 100;
            long comparedTo = 100;

            // Act
            Action action = () => { Check.AreNotEqual(value, comparedTo); };

            // Assert
            action.Should().ThrowExactly<GuardException>();
        }

        [Fact]
        public void ThrowException_WithMessage_WhenAreEqual()
        {
            // Arrange
            long value = 100;
            long comparedTo = 100;
            string message = "message";

            // Act
            Action action = () => { Check.AreNotEqual(value, comparedTo, message); };

            // Assert
            action.Should().ThrowExactly<GuardException>()
               .WithMessage(message);
        }
    }
}