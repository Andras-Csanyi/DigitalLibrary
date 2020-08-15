// <copyright file="OnUpdate_Validation_Should.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DigitalLibrary.Ui.WebUI.Test.SourceFormatBuilderService
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using FluentAssertions;

    using Utils.Guards;

    using WebUi.Components.SourceFormatBuilder;

    using Xunit;

    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "CA1707")]
    public class OnUpdate_Validation_Should : TestBase
    {
        [Fact]
        public void ThrowException_WhenInputIsInvalid()
        {
            // Arrange
            ISourceFormatBuilderService builder = new SourceFormatBuilderService(
                _masterDataWebApiClientMock.Object,
                _masterDataValidatorsMock.Object,
                _domainEntityHelperServiceMock.Object);

            // Act
            Func<Task> action = async () => { await builder.OnUpdate(0).ConfigureAwait(false); };

            // Assert
            action.Should().ThrowExactly<GuardException>();
        }
    }
}