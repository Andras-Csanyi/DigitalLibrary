namespace DigitalLibrary.IaC.ControlPanel.BusinessLogic.Implementations.Tests.Tests.Menu
{
    using System.Collections.Generic;
    using System.Reflection;
    using System.Threading.Tasks;

    using DomainModel.Entities;

    using FluentAssertions;

    using Xunit;

    [Collection(nameof(AssemblyName.GetAssemblyName))]
    public class MenuBusinessLogic_GetAllAsync_Should : TestBase
    {
        [Trait("Category", "Unit")]
        public async Task Return_AllItems()
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
            List<Menu> result = await MenuBusinessLogic.GetAllAsync().ConfigureAwait(false);

            // Assert
            result.Count.Should().Be(2);
        }
    }
}