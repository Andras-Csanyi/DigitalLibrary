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
        /// <summary>
        ///     WARNING!!! It is used only when SourceFormat is built.
        /// </summary>
        public ICollection<DimensionStructure> ChildDimensionStructures { get; set; } =
            new List<DimensionStructure>();

        public ICollection<DimensionStructureNode> ParentDimensionStructures { get; set; } =
            new List<DimensionStructureNode>();

        public ICollection<DimensionStructureNode> ChildDimensionStructures2 { get; set; } =
            new List<DimensionStructureNode>();

        public string Desc { get; set; }

        public Dimension Dimension { get; set; }

        public long? DimensionId { get; set; }

        /// <summary>
        /// The tree which describes the whole document structure.
        /// </summary>
        public ICollection<DimensionStructureDimensionStructure> DimensionStructureDimensionStructures { get; set; } =
            new List<DimensionStructureDimensionStructure>();

        public int IsActive { get; set; }

        public string Name { get; set; }

        public int SortOrder { get; set; }

        /// <summary>
        /// List of <see cref="SourceFormat"/>s where this <see cref="DimensionStructure"/>
        /// is the root <see cref="DimensionStructure"/> in the <see cref="DimensionStructure"/>
        /// tree.
        /// </summary>
        public ICollection<SourceFormat> SourceFormatsRootDimensionStructures { get; set; }
            = new List<SourceFormat>();

        public Guid Guid { get; set; } = Guid.NewGuid();

        public long Id { get; set; }
    }
}