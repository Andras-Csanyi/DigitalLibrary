namespace Guard.Tests
{
    using System;
    using System.Threading.Tasks;

    using DigitalLibrary.Utils.Guards;

    using FluentAssertions;

    using Xunit;

    public class LongAreEqualShould
    {
        [Fact]
        public void NotThrowException_WhenValuesArentEqual()
        {
            // Arrange
            long value = 100;
            long comparedTo = 99;

            // Act
            Func<Task> action = async () => { Check.AreNotEqual(value, comparedTo); };

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
            Func<Task> action = async () => { Check.AreNotEqual(value, comparedTo); };

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
            Func<Task> action = async () => { Check.AreNotEqual(value, comparedTo, message); };

            // Assert
            action.Should().ThrowExactly<GuardException>()
               .WithMessage(message);
        }
    }
}