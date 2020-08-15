// <copyright file="MenuBusinessLogic_GetAllAsync_Should.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.ControlPanel.BusinessLogic.Implementations.Unit.Tests.Menu
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using FluentAssertions;

    using Xunit;

    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "CA1707", Justification = "Reviewed.")]
    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "UnusedVariable", Justification = "Reviewed.")]
    public class MenuBusinessLogic_GetAllAsync_Should : TestBase
    {
        public MenuBusinessLogic_GetAllAsync_Should()
            : base(TestInfo)
        {
        }

        private const string TestInfo = nameof(MenuBusinessLogic_GetAllAsync_Should);

        [Fact]
        [Trait("Category", "Unit")]
        public async Task Return_AllItems()
        {
            // Arrange
            DomainModel.Entities.Module module = new DomainModel.Entities.Module
            {
                Name = "asd", Description = "desc", IsActive = 1, ModuleRoute = "asd",
            };
            DomainModel.Entities.Module moduleResult = await ModuleBusinessLogic.AddAsync(module).ConfigureAwait(false);

            DomainModel.Entities.Menu menuActive = new DomainModel.Entities.Menu
            {
                Name = "name",
                Description = "desc",
                IsActive = 1,
                ModuleId = 1,
                MenuRoute = "asd",
            };
            DomainModel.Entities.Menu menuActiveResult =
                await MenuBusinessLogic.AddAsync(menuActive).ConfigureAwait(false);

            DomainModel.Entities.Menu menuInactive = new DomainModel.Entities.Menu
            {
                Name = "name",
                Description = "desc",
                IsActive = 0,
                ModuleId = 1,
                MenuRoute = "asd",
            };
            DomainModel.Entities.Menu menuInactiveResult =
                await MenuBusinessLogic.AddAsync(menuInactive).ConfigureAwait(false);

            // Act
            List<DomainModel.Entities.Menu> result = await MenuBusinessLogic.GetAllAsync().ConfigureAwait(false);

            // Assert
            result.Count.Should().Be(2);
        }
    }
}