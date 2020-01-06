namespace DigitalLibrary.IaC.TeamManager.DomainModel.Entities
{
    using System.Collections.Generic;

    public class Position
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public int IsActive { get; set; }

        public IEnumerable<People> Peoples { get; set; }
    }
}