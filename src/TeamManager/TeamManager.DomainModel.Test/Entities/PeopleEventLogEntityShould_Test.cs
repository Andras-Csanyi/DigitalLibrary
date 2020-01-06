namespace DigitalLibrary.IaC.TeamManager.DomainModel.Test.Entities
{
    using DomainModel.Entities;

    using FluentAssertions;

    using Xunit;

    public class PeopleEventLogEntityShould_Test
    {
        [Trait("Category", "Unit")]
        public void ShouldNotChangeValue_DuringGetSetOperation()
        {
            // Arrage
            int id = 100;
            int eventId = 200;
            string details = "asdasdasdasdasd";
            int isActive = 1;
            int peopleId = 400;

            // Act
            PeopleEventLog peopleEventLog = new PeopleEventLog
            {
                Id = id,
                Details = details,
                EventId = eventId,
                IsActive = isActive,
                PeopleId = peopleId
            };

            // Assert
            peopleEventLog.Id.Should().Be(id);
            peopleEventLog.Details.Should().Be(details);
            peopleEventLog.EventId.Should().Be(eventId);
            peopleEventLog.IsActive.Should().Be(isActive);
            peopleEventLog.PeopleId.Should().Be(peopleId);
        }
    }
}