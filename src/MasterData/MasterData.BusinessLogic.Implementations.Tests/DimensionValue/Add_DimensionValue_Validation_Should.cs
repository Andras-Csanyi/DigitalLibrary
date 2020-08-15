// <copyright file="Add_DimensionValue_Validation_Should.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.DimensionValue
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DomainModel;

    using Exceptions;

    using FluentAssertions;

    using Xunit;

    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Reviewed.")]
    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "CA1707", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    public class Add_DimensionValue_Validation_Should : TestBase
    {
        private const string TestInfo = nameof(Add_DimensionValue_Validation_Should);

        public Add_DimensionValue_Validation_Should()
            : base(TestInfo)
        {
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(100, 100)]
        public void Throw_MasterDataBusinessLogicAddDimensionValueOperationException_WhenInputIsNull(
            long dimensionId,
            long dimensionValueId)
        {
            // Arrange
            DimensionValue dimensionValue = new DimensionValue
            {
                Id = dimensionValueId
            };

            // Act
            Func<Task> action = async () =>
            {
                await masterDataBusinessLogic.AddDimensionValueAsync(dimensionValue, dimensionId)
                   .ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataBusinessLogicAddDimensionValueAsyncOperationException>();
        }
    }
}