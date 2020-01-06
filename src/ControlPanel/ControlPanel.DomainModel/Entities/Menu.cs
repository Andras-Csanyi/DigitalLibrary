namespace DigitalLibrary.IaC.ControlPanel.DomainModel.Entities
{
    public class Menu
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string MenuRoute { get; set; }

        public long ModuleId { get; set; }

        public Module Module { get; set; }

        public int IsActive { get; set; }
    }
}