// <copyright file="MenuBusinessLogic_AddAsync_Should.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.ControlPanel.BusinessLogic.Implementations.Unit.Tests.Menu
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DigitalLibrary.ControlPanel.BusinessLogic.Exceptions.Menu;

    using FluentAssertions;

    using FluentValidation;

    using Xunit;

    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "CA1707", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "CA2211", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "TooManyArguments", Justification = "Reviewed.")]
    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "SA1600", Justification = "tmp")]
    [SuppressMessage("ReSharper", "SA1201", Justification = "tmp")]
    public class MenuBusinessLogic_AddAsync_Should : TestBase
    {
        private const string TestInfo = nameof(MenuBusinessLogic_AddAsync_Should);

        public MenuBusinessLogic_AddAsync_Should()
            : base(TestInfo)
        {
        }

        [SuppressMessage("ReSharper", "SA1401", Justification = "tmp")]
        public static IEnumerable<object[]> ThrowValidationExceptionWhenInputIsInvalid = new List<object[]>
        {
            new object[] { 1, "asd", "asd", 0, 1, "asd" },

            new object[] { 0, null, "asd", 0, 1, "asd" },
            new object[] { 0, string.Empty, "asd", 0, 1, "asd" },
            new object[] { 0, " ", "asd", 0, 1, "asd" },

            new object[] { 0, "asd", null, 0, 1, "asd" },
            new object[] { 0, "asd", string.Empty, 0, 1, "asd" },
            new object[] { 0, "asd", " ", 0, 1, "asd" },

            new object[] { 0, "asd", "asd", 0, 1, "asd" },

            new object[] { 0, "asd", "asd", 0, 2, "asd" },

            new object[] { 0, "asd", "asd", 0, 1, null },
            new object[] { 0, "asd", "asd", 0, 1, string.Empty },
            new object[] { 0, "asd", "asd", 0, 1, " " },
        };

        [Trait("Category", "Unit")]
        [Theory]
        [MemberData(nameof(ThrowValidationExceptionWhenInputIsInvalid))]
        public void Throw_ValidationException_WhenInputIsInvalid(
            int id,
            string name,
            string desc,
            int moduleId,
            int isActive,
            string menuRoute)
        {
            // Arrange
            DomainModel.Entities.Menu menu = new DomainModel.Entities.Menu
            {
                Id = id,
                Name = name,
                Description = desc,
                ModuleId = moduleId,
                IsActive = isActive,
                MenuRoute = menuRoute,
            };

            // Act
            Func<Task> action = async () => { await MenuBusinessLogic.AddAsync(menu).ConfigureAwait(false); };

            // Assert
            action.Should().ThrowExactly<MenuBusinessLogicAddAsyncOperationException>()
               .WithInnerException<ValidationException>();
        }

        [Fact]
        [Trait("Category", "Unit")]
        public async Task Add_Menu()
        {
            // Arrange
            DomainModel.Entities.Module module = new DomainModel.Entities.Module
            {
                Name = "asd",
                Description = "desc",
                IsActive = 1,
                ModuleRoute = "asd",
            };
            DomainModel.Entities.Module moduleResult = await ModuleBusinessLogic.AddAsync(module).ConfigureAwait(false);

            DomainModel.Entities.Menu menu = new DomainModel.Entities.Menu
            {
                Name = "name",
                Description = "desc",
                ModuleId = moduleResult.Id,
                IsActive = 1,
                MenuRoute = "asd",
            };

            // Act
            DomainModel.Entities.Menu menuResult = await MenuBusinessLogic.AddAsync(menu).ConfigureAwait(false);

            // Assert
            menuResult.Id.Should().BeGreaterThan(0);
            menuResult.Description.Should().Be(menu.Description);
            menuResult.Name.Should().Be(menu.Name);
            menuResult.IsActive.Should().Be(menu.IsActive);
            menuResult.ModuleId.Should().Be(menu.ModuleId);
            menuResult.MenuRoute.Should().Be(menu.MenuRoute);
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void Throw_NullInputException_WhenInputIsNull()
        {
            // Arrange

            // Act
            Func<Task> action = async () => { await MenuBusinessLogic.AddAsync(null).ConfigureAwait(false); };

            // Assert
            action.Should().ThrowExactly<MenuBusinessLogicAddAsyncOperationException>()
               .WithInnerException<MenuNullInputException>();
        }
    }
}
