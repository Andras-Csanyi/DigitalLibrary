// <copyright file="DimensionStructureDimensionStructure.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.DomainModel
{
    using DigitalLibrary.MasterData.DomainModel.Interfaces;

    public class DimensionStructureDimensionStructure : IHaveId
    {
        public long ChildDimensionStructureId { get; set; }

        public DimensionStructure DimensionStructure { get; set; }

        public long DimensionStructureId { get; set; }

        public long ParentDimensionStructureId { get; set; }

        public long Id { get; set; }
    }
}