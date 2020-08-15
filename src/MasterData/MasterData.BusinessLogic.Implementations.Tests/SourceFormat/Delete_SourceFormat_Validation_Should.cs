// <copyright file="Delete_SourceFormat_Validation_Should.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.SourceFormat
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DomainModel;

    using Exceptions;

    using FluentAssertions;

    using FluentValidation;

    using Utils.Guards;

    using Xunit;

    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Reviewed.")]
    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "CA1707", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    public class Delete_SourceFormat_Validation_Should : TestBase
    {
        public Delete_SourceFormat_Validation_Should() : base(TestInfo)
        {
        }

        private const string TestInfo = nameof(Delete_SourceFormat_Validation_Should);

        [Fact]
        public void ThrowException_WhenInputIsInvalid()
        {
            // Arrange
            SourceFormat sourceFormat = new SourceFormat
            {
                Id = 0
            };

            // Act
            Func<Task> action = async () =>
            {
                await masterDataBusinessLogic.DeleteSourceFormatAsync(sourceFormat)
                   .ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataBusinessLogicDeleteSourceFormatAsyncOperationException>()
               .WithInnerException<ValidationException>();
        }

        [Fact]
        public void ThrowException_WhenInputIsNull()
        {
            // Arrange

            // Act
            Func<Task> action = async () =>
            {
                await masterDataBusinessLogic.DeleteSourceFormatAsync(null)
                   .ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataBusinessLogicDeleteSourceFormatAsyncOperationException>()
               .WithInnerException<GuardException>();
        }
    }
}