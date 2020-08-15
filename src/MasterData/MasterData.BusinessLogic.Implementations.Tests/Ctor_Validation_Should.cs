// <copyright file="Ctor_Validation_Should.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    using FluentAssertions;

    using Utils.Guards;

    using Xunit;

    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Reviewed.")]
    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "CA1707", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    public class Ctor_Validation_Should : TestBase
    {
        public Ctor_Validation_Should()
            : base(TestInfo)
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