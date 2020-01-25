namespace DigitalLibrary.ControlPanel.DomainModel.Entities
{
    using System.Collections.Generic;

    public class Module
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ModuleRoute { get; set; }

        public int IsActive { get; set; }

        public ICollection<Menu> Menus { get; set; } = new List<Menu>();

        public string IconName { get; set; }
    }
}