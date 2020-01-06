namespace DigitalLibrary.IaC.TeamManager.DomainModel.Entities
{
    using System.Collections.Generic;

    public class Company
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public int IsActive { get; set; }

        public IEnumerable<People> Peoples { get; set; }
    }
}