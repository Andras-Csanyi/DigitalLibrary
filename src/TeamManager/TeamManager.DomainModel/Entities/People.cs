namespace DigitalLibrary.IaC.TeamManager.DomainModel.Entities
{
    using System.Collections.Generic;

    public class People
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public Company Company { get; set; }

        public long CompanyId { get; set; }

        public Position Position { get; set; }

        public long PositionId { get; set; }

        public Title Title { get; set; }

        public long TitleId { get; set; }

        public int IsActive { get; set; }

        public IEnumerable<PeopleEventLog> PeopleEventLogs { get; set; }
    }
}