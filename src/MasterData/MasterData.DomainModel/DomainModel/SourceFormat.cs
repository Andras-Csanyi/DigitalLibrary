// <copyright file="SourceFormat.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.DomainModel
{
    using System;
    using System.Collections.Generic;

    using DigitalLibrary.MasterData.DomainModel.Interfaces;

    public class SourceFormat : IHaveId, IHaveName, IHaveGuidId
    {
        public string Desc { get; set; }

        public int IsActive { get; set; }

        public SourceFormatDimensionStructureNode SourceFormatDimensionStructureNode { get; set; }

        public Guid Guid { get; set; } = Guid.NewGuid();

        public long Id { get; set; }

        public string Name { get; set; }

        public ICollection<DimensionStructureNode> DimensionStructureNodes { get; set; }
    }
}