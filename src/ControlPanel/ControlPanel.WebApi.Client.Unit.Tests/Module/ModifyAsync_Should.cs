// <copyright file="ModifyAsync_Should.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.ControlPanel.WebApi.Client.Unit.Tests.Module
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using Client.Menu.Exceptions;

    using FluentAssertions;

    using Xunit;

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "CA1707")]
    [ExcludeFromCodeCoverage]
    public class ModifyAsync_Should : TestBase
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
                   .ModifyModuleAsync(null).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<ControlPanelWebApiClientModifyModuleAsyncOperationException>();
        }
    }
}