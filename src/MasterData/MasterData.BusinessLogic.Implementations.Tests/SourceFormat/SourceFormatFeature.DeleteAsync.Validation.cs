// <copyright file="SourceFormatFeature.DeleteAsync.Validation.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.SourceFormat
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.Exceptions;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    using FluentAssertions;

    using FluentValidation;

    using Xbehave;

    using Xunit;

    /// <summary>
    /// Test cases covering Delete method validation.
    /// </summary>
    public partial class SourceFormatFeature
    {
        [Scenario]
        public void DeleteAsync_ThrowsWhenInputIsInvalid()
        {
            // Arrange
            SourceFormat sourceFormat = null;
            Func<Task> action = null;

            "Given I'd like to delete a source format"
               .x(() => sourceFormat = new SourceFormat
                {
                    Id = 0,
                });

            "When the input is invalid"
               .x(() => action = async () =>
                {
                    await _masterDataBusinessLogic.DeleteSourceFormatAsync(sourceFormat)
                       .ConfigureAwait(false);
                });

            "Then it throws exception"
               .x(() => action.Should()
                   .ThrowExactly<MasterDataBusinessLogicDeleteSourceFormatAsyncOperationException>()
                   .WithInnerException<ValidationException>());
        }

        [Scenario]
        public void DeleteAsync_ThrowsWhenInputIsNull()
        {
            Func<Task> action = null;

            "When I try to delete source format and input is null"
               .x(() => action = async () =>
                {
                    await _masterDataBusinessLogic.DeleteSourceFormatAsync(null)
                       .ConfigureAwait(false);
                });

            "Then it throws exception"
               .x(() => action.Should()
                   .ThrowExactly<MasterDataBusinessLogicDeleteSourceFormatAsyncOperationException>()
                   .WithInnerException<GuardException>());
        }
    }
}