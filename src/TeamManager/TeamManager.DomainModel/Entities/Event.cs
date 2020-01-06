namespace DigitalLibrary.IaC.TeamManager.DomainModel.Entities
{
    using System.Collections.Generic;

    public class Event
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public int IsActive { get; set; }

        public IEnumerable<PeopleEventLog> PeopleEventLogs { get; set; }
    }
}