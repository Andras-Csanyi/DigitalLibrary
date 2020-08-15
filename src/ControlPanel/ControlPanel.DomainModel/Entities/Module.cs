// <copyright file="Module.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.ControlPanel.DomainModel.Entities
{
    using System.Collections.Generic;

    public class Module
    {
        public string Description { get; set; }

        public string IconName { get; set; }

        public long Id { get; set; }

        public int IsActive { get; set; }

        public ICollection<Menu> Menus { get; set; } = new List<Menu>();

        public string ModuleRoute { get; set; }

        public string Name { get; set; }
    }
}