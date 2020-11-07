// <copyright file="SourceFormat.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.DomainModel
{
    using System;
    using System.Collections.Generic;

    using DigitalLibrary.MasterData.DomainModel.Interfaces;

    /// <summary>
    ///     SourceFormat MasterData domain entity.
    ///     A <see cref="SourceFormat" /> describes two things:
    ///     <list type="bullets">
    ///         <item>Source of the data - where the data comes from.</item>
    ///         <item>Type of the data and structure of the data.</item>
    ///     </list>
    /// </summary>
    public class SourceFormat : IHaveId, IHaveName, IHaveGuidId
    {
        /// <summary>
        ///     Gets or set Desc value.
        ///     <remarks>
        ///         Contains extra data about the <see cref="SourceFormat" />.
        ///     </remarks>
        /// </summary>
        public string Desc { get; set; }

        /// <summary>
        ///     Gets or sets DimensionStructureNodes value.
        ///     <remarks>
        ///         The collection of <see cref="DimensionStructureNode" /> contains all the node belong to
        ///         the <see cref="SourceFormat" />. Having this makes possible to find nodes easily.
        ///     </remarks>
        /// </summary>
        public ICollection<DimensionStructureNode> DimensionStructureNodes { get; set; }

        /// <summary>
        ///     Gets os sets IsActive value.
        ///     <remarks>
        ///         It indicates whether the given <see cref="SourceFormat" /> is enabled or disabled.
        ///         Logical delete is needed in order to disable <see cref="SourceFormat" />s without data loss.
        ///     </remarks>
        /// </summary>
        public int IsActive { get; set; }

        /// <summary>
        ///     Gets or sets SourceFormatDimensionStructureNode value.
        ///     <remarks>
        ///         This navigation property points to a <see cref="DimensionStructureNode" /> which is the root
        ///         element of a tree describing what the document structure looks like.
        ///     </remarks>
        /// </summary>
        public SourceFormatDimensionStructureNode SourceFormatDimensionStructureNode { get; set; }

        /// <inheritdoc />
        public Guid Guid { get; set; } = Guid.NewGuid();

        /// <inheritdoc />
        public long Id { get; set; }

        /// <inheritdoc />
        public string Name { get; set; }
    }
}