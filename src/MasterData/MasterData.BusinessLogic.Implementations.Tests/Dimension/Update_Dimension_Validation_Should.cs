// <copyright file="Update_Dimension_Validation_Should.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.Dimension
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DomainModel;

    using Exceptions;

    using FluentAssertions;

    using FluentValidation;

    using Utils.Guards;

    using Validators.TestData;

    using Xunit;

    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "CA1707")]
    [SuppressMessage("ReSharper", "TooManyArguments")]
    public class Update_Dimension_Validation_Should : TestBase
    {
        public Update_Dimension_Validation_Should() : base(TestInfo)
        {
        }

        private const string TestInfo = nameof(Update_Dimension_Validation_Should);

        [Theory]
        [MemberData(nameof(MasterData_Dimension_TestData.UpdateDimensionAsync_Validation),
            MemberType = typeof(MasterData_Dimension_TestData))]
        public void ThrowException_WhenInputIsInvalid(
            long id,
            string name,
            string desc,
            int isActive)
        {
            // Arrange
            Dimension dimension = new Dimension
            {
                Id = id,
                Name = name,
                Description = desc,
                IsActive = isActive
            };

            // Act
            Func<Task> action = async () =>
            {
                await masterDataBusinessLogic.UpdateDimensionAsync(dimension).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataBusinessLogicUpdateDimensionAsyncOperationException>()
               .WithInnerException<ValidationException>();
        }

        [Fact]
        public void ThrowException_WhenInputsAreNull()
        {
            // Arrange

            // Act
            Func<Task> action = async () =>
            {
                await masterDataBusinessLogic.UpdateDimensionAsync(null)
                   .ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataBusinessLogicUpdateDimensionAsyncOperationException>()
               .WithInnerException<GuardException>();
        }
    }
}