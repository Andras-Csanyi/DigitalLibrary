namespace DigitalLibrary.IaC.TeamManager.DomainModel.Entities
{
    public class PeopleEventLog
    {
        public long Id { get; set; }

        public string Details { get; set; }

        public int IsActive { get; set; }

        public People People { get; set; }

        public long PeopleId { get; set; }

        public Event Event { get; set; }

        public long EventId { get; set; }
    }
}