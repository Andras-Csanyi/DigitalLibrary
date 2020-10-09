// <copyright file="DimensionStructure.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.DomainModel
{
    using System;
    using System.Collections.Generic;

    using DigitalLibrary.MasterData.DomainModel.Interfaces;

    /// <summary>
    ///     DimensionStructure entity which represents a node in a DimensionStructure tree which
    ///     describes a document structure.
    /// </summary>
    public class DimensionStructure : IHaveId, IHaveGuidId
    {
        public ICollection<DimensionStructureNode> ChildNodes { get; set; }

        public ICollection<DimensionStructureNode> ReferencedNodes { get; set; }

        public string Desc { get; set; }

        public Dimension Dimension { get; set; }

        public long? DimensionId { get; set; }

        public int IsActive { get; set; }

        public string Name { get; set; }

        public int SortOrder { get; set; }

        public Guid Guid { get; set; } = Guid.NewGuid();

        public long Id { get; set; }

        public SourceFormatDimensionStructure SourceFormatDimensionStructure { get; set; }
    }
}