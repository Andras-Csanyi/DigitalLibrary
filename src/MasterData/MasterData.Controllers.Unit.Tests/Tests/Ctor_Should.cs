// <copyright file="Ctor_Should.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DigitalLibrary.MasterData.Controllers.Unit.Tests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using DigitalLibrary.Utils.Guards;
    using FluentAssertions;
    using Xunit;

    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Reviewed.")]
    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "CA1707", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "CA1806", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "ObjectCreationAsStatement", Justification = "Reviewed.")]
    public class Ctor_Should
    {
        [Fact]
        public void ThrowException_WhenInputIsNull()
        {
            // Arrange

            // Act
            Action action = () => { new SourceFormatController(null); };

            // Assert
            action.Should().ThrowExactly<GuardException>();
        }
    }
}