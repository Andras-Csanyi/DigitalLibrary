namespace Guard.Tests
{
    using System;
    using System.Threading.Tasks;

    using DigitalLibrary.Utils.Guards;

    using FluentAssertions;

    using Xunit;
    using Xunit.Sdk;

    public class GuidAreEqualShould
    {
        [Fact]
        public void ThrowException_WhenAreEqual()
        {
            // Arrange
            Guid value = Guid.Empty;
            Guid comparedTo = Guid.Empty;

            // Act
            Func<Task> action = async () => { Check.AreNotEqual(value, comparedTo); };

            // Assert
            action.Should().ThrowExactly<GuardException>();
        }

        [Fact]
        public void ThrowException_WithMessage_WhenAreEqual()
        {
            // Arrange
            Guid value = Guid.Empty;
            Guid comparedTo = Guid.Empty;
            string message = "message";

            // Act
            Func<Task> action = async () => { Check.AreNotEqual(value, comparedTo, message); };

            // Assert
            action.Should().ThrowExactly<GuardException>()
               .WithMessage(message);
        }

        [Fact]
        public void NotThrowException_WhenValuesArentEqual()
        {
            // Arrange
            Guid value = Guid.NewGuid();
            Guid comparedTo = Guid.NewGuid();

            // Act
            Func<Task> action = async () => { Check.AreNotEqual(value, comparedTo); };

            // Assert
            action.Should().NotThrow();
        }
    }
}