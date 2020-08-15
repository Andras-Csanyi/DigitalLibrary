// <copyright file="Menu.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.ControlPanel.DomainModel.Entities
{
    public class Menu
    {
        public string Description { get; set; }

        public long Id { get; set; }

        public int IsActive { get; set; }

        public string MenuRoute { get; set; }

        public Module Module { get; set; }

        public long ModuleId { get; set; }

        public string Name { get; set; }
    }
}