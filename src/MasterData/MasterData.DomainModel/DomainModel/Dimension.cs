// <copyright file="Dimension.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.DomainModel
{
    using System.Collections.Generic;
    using DigitalLibrary.MasterData.DomainModel.Interfaces;

    public class Dimension : IHaveId, IHaveName
    {
        public string Description { get; set; }

        public ICollection<DimensionDimensionValue> DimensionDimensionValues { get; set; }

        public ICollection<DimensionStructure> DimensionStructure { get; set; }

        public int IsActive { get; set; }

        public Dimension()
        {
        }

        public long Id { get; set; }

        public string Name { get; set; }
    }
}