// <copyright file="AddAsync_Should.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.ControlPanel.WebApi.Client.Unit.Tests.Menu
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DigitalLibrary.ControlPanel.WebApi.Client.Menu.Exceptions;

    using FluentAssertions;

    using Xunit;

    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "CA1707", Justification = "Reviewed.")]
    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    public class AddAsync_Should : TestBase
    {
        [Fact]
        [Trait("Category", "Unit")]
        public void Throw_ArgumentNullException_WhenInputIsNull()
        {
            // Arrange

            // Act
            Func<Task> action = async () =>
            {
                await ControlPanelWebApiClient
                   .AddMenuAsync(null).ConfigureAwait(false);
            };

            // Arrange
            action.Should().ThrowExactly<ControlPanelWebApiClientAddMenuAsyncOperationException>();
        }
    }
}
