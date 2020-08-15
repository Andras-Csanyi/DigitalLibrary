// <copyright file="GuidAreEqualShould.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Guard.Tests
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    using DigitalLibrary.Utils.Guards;

    using FluentAssertions;

    using Xunit;

    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "CA1707")]
    public class GuidAreEqualShould
    {
        [Fact]
        public void NotThrowException_WhenValuesArentEqual()
        {
            // Arrange
            Guid value = Guid.NewGuid();
            Guid comparedTo = Guid.NewGuid();

            // Act
            Action action = () => { Check.AreNotEqual(value, comparedTo); };

            // Assert
            action.Should().NotThrow();
        }

        [Fact]
        public void ThrowException_WhenAreEqual()
        {
            // Arrange
            Guid value = Guid.Empty;
            Guid comparedTo = Guid.Empty;

            // Act
            Action action = () => { Check.AreNotEqual(value, comparedTo); };

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
            Action action = () => { Check.AreNotEqual(value, comparedTo, message); };

            // Assert
            action.Should().ThrowExactly<GuardException>()
               .WithMessage(message);
        }
    }
}