namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Implementations.Tests.Tests.Event
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DomainModel.Entities;

    using Exceptions.Exceptions.Event;

    using FluentAssertions;

    using FluentValidation;

    using Xunit;

    public class EventBusinessLogic_DeleteAsync_Should : TestBase
    {
        [Trait("Category", "Unit")]
        public async Task Throw_EventDeleteAsyncOperationException_WhenInputIsNull()
        {
            // Arrange

            // Act
            Func<Task> action = async () => { await EventBusinessLogic.DeleteAsync(null).ConfigureAwait(false); };

            // Assert
            action.Should().ThrowExactly<EventDeleteAsyncOperationException>()
                .WithInnerException<EventInputNullException>();
        }

        [Trait("Category", "Unit")]
        public async Task Throw_EventDeleteAsyncOperationException_WhenInputIsInvalid()
        {
            // Arrange
            Event evnt = new Event { Id = 0 };

            // Act
            Func<Task> action = async () => { await EventBusinessLogic.DeleteAsync(evnt).ConfigureAwait(false); };

            // Assert
            action.Should().ThrowExactly<EventDeleteAsyncOperationException>()
                .WithInnerException<ValidationException>();
        }

        [Trait("Category", "Unit")]
        public async Task Should_DeleteAnItem()
        {
            // Arrange
            Event ev1 = new Event { Name = "asd", IsActive = 1 };
            Event ev2 = new Event { Name = "asd2", IsActive = 1 };

            Event rs1 = await EventBusinessLogic.AddAsync(ev1).ConfigureAwait(false);
            Event rs2 = await EventBusinessLogic.AddAsync(ev2).ConfigureAwait(false);

            // Act
            await EventBusinessLogic.DeleteAsync(rs2).ConfigureAwait(false);

            List<Event> result = await EventBusinessLogic.GetAllAsync().ConfigureAwait(false);

            // Assert
            result.Count.Should().Be(1);
            result.FirstOrDefault().Id.Should().NotBe(rs2.Id);
        }
    }
}