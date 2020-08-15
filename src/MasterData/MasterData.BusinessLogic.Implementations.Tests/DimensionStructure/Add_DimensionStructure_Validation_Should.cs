// <copyright file="Add_DimensionStructure_Validation_Should.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.DimensionStructure
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
    public class Add_DimensionStructure_Validation_Should : TestBase
    {
        public Add_DimensionStructure_Validation_Should() : base(TestInfo)
        {
        }

        private const string TestInfo = nameof(Add_DimensionStructure_Validation_Should);

        [Theory]
        [MemberData(nameof(MasterData_DimensionStructure_TestData.AddDimensionStructure_Validation_TestData),
            MemberType = typeof(MasterData_DimensionStructure_TestData))]
        public void ThrowException_WhenInputIsInvalid(
            long id,
            string name,
            string desc,
            int isActive)
        {
            // Arrange
            DimensionStructure dimensionStructure = new DimensionStructure
            {
                Id = id,
                Name = name,
                Desc = desc,
                IsActive = isActive
            };

            // Act
            Func<Task> action = async () =>
            {
                await masterDataBusinessLogic.AddDimensionStructureAsync(dimensionStructure).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataBusinessLogicAddDimensionStructureAsyncOperationException>()
               .WithInnerException<ValidationException>();
        }

        [Fact]
        public void ThrowException_WhenInputIsNull()
        {
            // Arrange

            // Act
            Func<Task> action = async () =>
            {
                await masterDataBusinessLogic.AddDimensionStructureAsync(null).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataBusinessLogicAddDimensionStructureAsyncOperationException>()
               .WithInnerException<GuardException>();
        }
    }
}