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
    ///     DimensionStructure entity which describes information part of a node
    ///     in the DimensionStructure tree.
    ///     Structural information is described by <see cref="DimensionStructureNode"/> object.
    /// </summary>
    public class DimensionStructure : IHaveId, IHaveGuidId
    {
        public string Desc { get; set; }

        public Dimension Dimension { get; set; }

        public long? DimensionId { get; set; }

        public ICollection<DimensionStructureNode> DimensionStructureNodes { get; set; }

        public int IsActive { get; set; }

        public string Name { get; set; }

        public int SortOrder { get; set; }

        public Guid Guid { get; set; } = Guid.NewGuid();

        public long Id { get; set; }
    }
}