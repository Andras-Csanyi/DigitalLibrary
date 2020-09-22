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
    public partial interface IMasterDataBusinessLogic
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

        Task<SourceFormat> GetSourceFormatByIdWithFullDimensionStructureTreeAsync(SourceFormat querySourceFormat);

        Task<List<SourceFormat>> GetSourceFormatsAsync();

        Task<SourceFormat> UpdateSourceFormatAsync(SourceFormat sourceFormat);
    }
}