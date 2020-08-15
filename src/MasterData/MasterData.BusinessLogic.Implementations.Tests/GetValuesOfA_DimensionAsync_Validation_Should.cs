// <copyright file="GetValuesOfA_DimensionAsync_Validation_Should.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using Exceptions;

    using FluentAssertions;

    using Utils.Guards;

    using Xunit;

    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Reviewed.")]
    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "CA1707", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    public class GetValuesOfA_DimensionAsync_Validation_Should : TestBase
    {
        public GetValuesOfA_DimensionAsync_Validation_Should() : base(TestInfo)
        {
        }

        private const string TestInfo = nameof(GetValuesOfA_DimensionAsync_Validation_Should);

        [Fact]
        public void ThrowException_WhenInputIsNull()
        {
            // Arrange

            // Act
            Func<Task> action = async () =>
            {
                await masterDataBusinessLogic.GetValuesOfADimensionAsync(0)
                   .ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataBusinessLogicGetDimensionValueAsyncOperationException>()
               .WithInnerExceptionExactly<GuardException>();
        }
    }
}