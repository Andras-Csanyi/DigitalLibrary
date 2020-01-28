namespace DigitalLibrary.ControlPanel.BusinessLogic.Implementations.Unit.Tests.Menu
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Threading.Tasks;

    using Exceptions.Menu;

    using FluentAssertions;

    using Xunit;

    public class MenuBusinessLogic_DeleteAsync_Should : TestBase
    {
        private const string TestInfo = nameof(MenuBusinessLogic_DeleteAsync_Should);

        public MenuBusinessLogic_DeleteAsync_Should() : base(TestInfo)
        {
        }

        [Fact]
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

        [Fact]
        [Trait("Category", "Unit")]
        public async Task Delete_AnItem()
        {
            // Arrange
            DomainModel.Entities.Module module = new DomainModel.Entities.Module
            {
                Name = "asd", Description = "desc", IsActive = 1, ModuleRoute = "asd"
            };
            DomainModel.Entities.Module moduleResult = await ModuleBusinessLogic.AddAsync(module).ConfigureAwait(false);

            DomainModel.Entities.Menu menuActive = new DomainModel.Entities.Menu
            {
                Name = "name",
                Description = "desc",
                IsActive = 1,
                ModuleId = 1,
                MenuRoute = "asd"
            };
            DomainModel.Entities.Menu menuActiveResult =
                await MenuBusinessLogic.AddAsync(menuActive).ConfigureAwait(false);

            DomainModel.Entities.Menu menuInactive = new DomainModel.Entities.Menu
            {
                Name = "name",
                Description = "desc",
                IsActive = 0,
                ModuleId = 1,
                MenuRoute = "asd"
            };
            DomainModel.Entities.Menu menuInactiveResult =
                await MenuBusinessLogic.AddAsync(menuInactive).ConfigureAwait(false);

            // Act
            await MenuBusinessLogic.DeleteAsync(menuInactiveResult).ConfigureAwait(false);
            List<DomainModel.Entities.Menu> result = await MenuBusinessLogic.GetAllAsync().ConfigureAwait(false);

            // Assert
            result.Count.Should().Be(1);
        }
    }
}