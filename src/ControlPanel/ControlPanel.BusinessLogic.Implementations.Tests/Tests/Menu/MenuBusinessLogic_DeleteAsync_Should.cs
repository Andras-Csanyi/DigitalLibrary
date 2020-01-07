namespace DigitalLibrary.IaC.ControlPanel.BusinessLogic.Implementations.Tests.Tests.Menu
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Threading.Tasks;

    using DomainModel.Entities;

    using Exceptions.Menu;

    using FluentAssertions;

    using Xunit;

    [Collection(nameof(AssemblyName.GetAssemblyName))]
    public class MenuBusinessLogic_DeleteAsync_Should : TestBase
    {
        [Trait("Category", "Unit")]
        public async Task Throw_DeleteAsyncOperationException_WhenInputIsNull()
        {
            // Arrange

            // Act
            Func<Task> action = async () => { await MenuBusinessLogic.DeleteAsync(null).ConfigureAwait(false); };

            // Assert
            action.Should().ThrowExactly<MenuBusinessLogicDeleteAsyncOperationException>()
                .WithInnerException<MenuNullInputException>();
        }

        [Trait("Category", "Unit")]
        public async Task Delete_AnItem()
        {
            // Arrange
            DomainModel.Entities.Module module = new DomainModel.Entities.Module
            {
                Name = "asd", Description = "desc", IsActive = 1, ModuleRoute = "asd"
            };
            DomainModel.Entities.Module moduleResult = await ModuleBusinessLogic.AddAsync(module).ConfigureAwait(false);

            Menu menuActive = new Menu
            {
                Name = "name",
                Description = "desc",
                IsActive = 1,
                ModuleId = 1,
                MenuRoute = "asd"
            };
            Menu menuActiveResult = await MenuBusinessLogic.AddAsync(menuActive).ConfigureAwait(false);

            Menu menuInactive = new Menu
            {
                Name = "name",
                Description = "desc",
                IsActive = 0,
                ModuleId = 1,
                MenuRoute = "asd"
            };
            Menu menuInactiveResult = await MenuBusinessLogic.AddAsync(menuInactive).ConfigureAwait(false);

            // Act
            await MenuBusinessLogic.DeleteAsync(menuInactiveResult).ConfigureAwait(false);
            List<Menu> result = await MenuBusinessLogic.GetAllAsync().ConfigureAwait(false);

            // Assert
            result.Count.Should().Be(1);
        }
    }
}