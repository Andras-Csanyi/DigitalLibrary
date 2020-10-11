// <copyright file="IMasterDataBusinessLogic.SourceFormat.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;

    /// <summary>
    ///     MasterDataBusinessLogic interface for <see cref="SourceFormat" />s.
    /// </summary>
    public interface IMasterDataSourceFormatBusinessLogic
    {
        /// <summary>
        ///     Saves a new <see cref="SourceFormat" /> in the database.
        /// </summary>
        /// <param name="sourceFormat">New SourceFormant</param>
        /// <returns>Saved SourceFormat.</returns>
        Task<SourceFormat> AddSourceFormatAsync(SourceFormat sourceFormat);

        Task<long> CountSourceFormatsAsync();

        Task DeleteSourceFormatAsync(SourceFormat secondResult);

        Task<SourceFormat> GetSourceFormatByIdAsync(SourceFormat sourceFormat);

        /// <summary>
        /// It returns a <see cref="SourceFormat"/> without its related entities.
        /// </summary>
        /// <param name="sourceFormat">SourceFormat query object.</param>
        /// <returns>The result.</returns>
        Task<SourceFormat> GetSourceFormatByNameAsync(SourceFormat sourceFormat);

        /// <summary>
        /// It returns a <see cref="SourceFormat"/> with its RootDimensionStructure attached.
        /// </summary>
        /// <param name="sourceFormat">SourceFormat query object.</param>
        /// <returns>The result.</returns>
        Task<SourceFormat> GetSourceFormatByNameWithRootDimensionStructureAsync(SourceFormat sourceFormat);

        /// <summary>
        /// Returns with <see cref="SourceFormat"/> which contains the full <see cref="DimensionStructure"/>
        /// tree.
        /// </summary>
        /// <param name="sourceFormat">SourceFormat query object.</param>
        /// <returns>The result.</returns>
        Task<SourceFormat> GetSourceFormatByNameWithFullDimensionStructureTreeAsync(SourceFormat sourceFormat);

        /// <summary>
        /// Returns with <see cref="SourceFormat"/> which brings its root <see cref="DimensionStructure"/>.
        /// </summary>
        /// <param name="querySourceFormat">Query object</param>
        /// <returns>Result or null.</returns>
        Task<SourceFormat> GetSourceFormatByIdWithRootDimensionStructureAsync(SourceFormat querySourceFormat);

        /// <summary>
        /// Returns with <see cref="SourceFormat"/> which has the <see cref="DimensionStructure"/> tree mounted.
        /// </summary>
        /// <param name="querySourceFormat">SourceFormat query object.</param>
        /// <returns>SourceFormat or null.</returns>
        Task<SourceFormat> GetSourceFormatByIdWithDimensionStructureTreeAsync(SourceFormat querySourceFormat);

        Task<List<SourceFormat>> GetSourceFormatsAsync();

        Task<SourceFormat> UpdateSourceFormatAsync(SourceFormat sourceFormat);

        /// <summary>
        /// Adds <see cref="DimensionStructure"/> to <see cref="SourceFormat"/> as
        /// root dimension structure.
        /// </summary>
        /// <param name="sourceFormatId">Source format id.</param>
        /// <param name="dimensionStructureId">Dimension structure id.</param>
        /// <returns>Task.</returns>
        Task AddRootDimensionStructureAsync(long sourceFormatId, long dimensionStructureId);

        /// <summary>
        /// Returns <see cref="SourceFormat"/> which has all <see cref="DimensionStructureNode"/>s and
        /// <see cref="DimensionStructure"/>s attached too.
        /// </summary>
        /// <param name="sourceFormat">Queryobject.</param>
        /// <returns>SourceFormat or null.</returns>
        Task<SourceFormat> GetSourceFormatByIdWithAllDimensionStructuresAndNodesAsync(SourceFormat sourceFormat);
    }
}