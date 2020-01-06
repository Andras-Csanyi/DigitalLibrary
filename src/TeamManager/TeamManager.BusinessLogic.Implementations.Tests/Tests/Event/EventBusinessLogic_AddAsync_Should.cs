namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Implementations.Tests.Tests.Event
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Threading.Tasks;

    using DomainModel.Entities;

    using Exceptions.Exceptions.Event;

    using FluentAssertions;

    using FluentValidation;

    using Xunit;

    [Collection(nameof(AssemblyName.GetAssemblyName))]
    public class EventBusinessLogic_AddAsync_Should : TestBase
    {
        public static IEnumerable<object[]> ThrowEventAddAsyncOperationExceptionWhenInputIsInvalid = new List<object[]>
        {
            new object[] { null, 1 },
            new object[] { string.Empty, 1 },
            new object[] { " ", 1 },
            new object[] { "asd", 2 },
        };

        [Trait("Category", "Unit")]
        public async Task Throw_EventAddAsyncOperationException_WhenInputIsNull()
        {
            // Arrange

            // Act
            Func<Task> action = async () => { await EventBusinessLogic.AddAsync(null).ConfigureAwait(false); };

            // Assert
            action.Should().ThrowExactly<EventAddAsyncOperationException>()
                .WithInnerException<EventInputNullException>();
        }

        [Trait("Category", "Unit")]
        [MemberData(nameof(ThrowEventAddAsyncOperationExceptionWhenInputIsInvalid))]
        public async Task Throw_EventAddAsyncOperationException_WhenInputIsInvalid(
            string name,
            int isActive)
        {
            // Arrange
            Event evnt = new Event
            {
                Name = name,
                IsActive = isActive
            };

            // Act
            Func<Task> action = async () => { await EventBusinessLogic.AddAsync(evnt).ConfigureAwait(false); };

            // Assert
            action.Should().ThrowExactly<EventAddAsyncOperationException>()
                .WithInnerException<ValidationException>();
        }

        [Trait("Category", "Unit")]
        public async Task Should_AddEvent()
        {
            // Arrange
            Event evnt = new Event
            {
                Name = "asd",
                IsActive = 1
            };

            // Act
            Event result = await EventBusinessLogic.AddAsync(evnt).ConfigureAwait(false);

            // Assert
            result.Id.Should().NotBe(0);
            result.Name.Should().Be(evnt.Name);
            result.IsActive.Should().Be(evnt.IsActive);
        }
    }
}