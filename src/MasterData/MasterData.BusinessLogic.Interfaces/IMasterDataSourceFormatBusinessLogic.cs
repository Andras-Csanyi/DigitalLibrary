// <copyright file="IMasterDataBusinessLogic.SourceFormat.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Interfaces
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;

    /// <summary>
    ///     MasterDataBusinessLogic interface for <see cref="SourceFormat" />s.
    /// </summary>
    public interface IMasterDataSourceFormatBusinessLogic
    {
        /// <summary>
        ///     Adds <see cref="DimensionStructure" /> to <see cref="SourceFormat" /> as
        ///     root dimension structure.
        /// </summary>
        /// <param name="sourceFormatId">Source format id.</param>
        /// <param name="dimensionStructureId">Dimension structure id.</param>
        /// <returns>Task.</returns>
        Task AddRootDimensionStructureAsync(long sourceFormatId, long dimensionStructureId);

        /// <summary>
        ///     Adds a new <see cref="SourceFormat" /> to the system.
        /// </summary>
        /// <param name="sourceFormat">New SourceFormant.</param>
        /// <param name="cancellationToken">
        /// <see cref="CancellationToken"/> token.
        /// </param>
        /// <returns>
        /// Returns a <see cref="Task"/> representing the result of asynchronous operation.
        /// </returns>
        /// <exception cref="MasterDataBusinessLogicSourceFormatDatabaseOperationException">
        /// An error happened during database operation.
        /// </exception>
        Task<SourceFormat> AddAsync(
            SourceFormat sourceFormat,
            CancellationToken cancellationToken = default);

        Task<long> CountSourceFormatsAsync();

        Task DeleteSourceFormatAsync(SourceFormat secondResult);

        /// <summary>
        /// Finds and returns with a <see cref="SourceFormat"/> by Id. 
        /// </summary>
        /// <param name="sourceFormat">Contains the Id of the queried <see cref="SourceFormat"/>.</param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
        /// <returns>
        /// Returns a <see cref="Task{TResult}"/> representing the result of an asynchronous operation.
        /// </returns>
        /// <exception cref="MasterDataBusinessLogicSourceFormatDatabaseOperationException">
        /// An error happened during database operation.
        /// </exception>
        Task<SourceFormat> GetByIdAsync(
            SourceFormat sourceFormat,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Returns <see cref="SourceFormat" /> which has both active and inactive
        /// <see cref="DimensionStructureNode" />s and
        ///     <see cref="DimensionStructure" />s attached too.
        /// </summary>
        /// <param name="sourceFormat">Queryobject.</param>
        /// <returns>SourceFormat or null.</returns>
        Task<SourceFormat> GetSourceFormatByIdWithAllDimensionStructuresAndNodesAsync(SourceFormat sourceFormat);

        /// <summary>
        /// Returns with <see cref="SourceFormat"/> which has only <see cref="DimensionStructureNode"/>s
        /// where the <see cref="DimensionStructure"/> is active.
        /// </summary>
        /// <param name="querySourceFormat">Query object.</param>
        /// <returns>SourceFormat or null.</returns>
        Task<SourceFormat> GetSourceFormatByIdWithActiveOnlyDimensionStructuresInTheTreeAsync(
            SourceFormat querySourceFormat);

        /// <summary>
        ///     Returns with <see cref="SourceFormat" /> which has the <see cref="DimensionStructure" /> tree
        /// attached. It includes both active and inactive nodes.
        /// </summary>
        /// <param name="querySourceFormat">SourceFormat query object.</param>
        /// <returns>SourceFormat or null.</returns>
        Task<SourceFormat> GetSourceFormatByIdWithDimensionStructureTreeAsync(SourceFormat querySourceFormat);

        /// <summary>
        ///     Returns with <see cref="SourceFormat" /> which brings its root <see cref="DimensionStructure" />.
        /// </summary>
        /// <param name="querySourceFormat">Query object.</param>
        /// <returns>Result or null.</returns>
        Task<SourceFormat> GetSourceFormatByIdWithRootDimensionStructureAsync(SourceFormat querySourceFormat);

        /// <summary>
        ///     It returns a <see cref="SourceFormat" /> without its related entities.
        /// </summary>
        /// <param name="sourceFormat">SourceFormat query object.</param>
        /// <returns>The result.</returns>
        Task<SourceFormat> GetSourceFormatByNameAsync(SourceFormat sourceFormat);

        /// <summary>
        ///     Returns with <see cref="SourceFormat" /> which contains the full <see cref="DimensionStructure" />
        ///     tree.
        /// </summary>
        /// <param name="sourceFormat">SourceFormat query object.</param>
        /// <returns>The result.</returns>
        Task<SourceFormat> GetSourceFormatByNameWithFullDimensionStructureTreeAsync(SourceFormat sourceFormat);

        /// <summary>
        ///     It returns a <see cref="SourceFormat" /> with its RootDimensionStructure attached.
        /// </summary>
        /// <param name="sourceFormat">SourceFormat query object.</param>
        /// <returns>The result.</returns>
        Task<SourceFormat> GetSourceFormatByNameWithRootDimensionStructureAsync(SourceFormat sourceFormat);

        /// <summary>
        /// Returns list of <see cref="SourceFormat"/> which includes both active and inactive ones.
        /// </summary>
        /// <param name="cancellationToken"> <see cref="CancellationToken"/>. </param>
        /// <returns>
        /// Returns with a <see cref="Task{TResult}"/> which contains a <see cref="List{T}"/> containing
        /// the <see cref="SourceFormat"/> objects available in the system.
        /// </returns>
        /// <exception cref="MasterDataBusinessLogicSourceFormatDatabaseOperationException">
        /// An error happened during database operation.
        /// </exception>
        Task<List<SourceFormat>> GetSourceFormatsAsync(CancellationToken cancellationToken = default);

        Task<SourceFormat> UpdateSourceFormatAsync(SourceFormat sourceFormat);

        /// <summary>
        /// Returns with <see cref="SourceFormat"/> with its <see cref="DimensionStructure"/> tree attached.
        /// It contains only the active tree.
        /// </summary>
        /// <param name="sourceFormatId">SourceFormat id.</param>
        /// <param name="cancellationToken">
        ///     <see cref="CancellationToken"/>Cancellation token.</param>
        /// <returns>
        ///     A task contains the SourceFormat.
        /// </returns>
        /// <exception cref="MasterDataBusinessLogicSourceFormatDatabaseOperationException">
        /// An error happened during database operation.
        /// </exception>
        Task<SourceFormat> GetSourceFormatByIdWithActiveDimensionStructureTreeAsync(
            long sourceFormatId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns with <see cref="DimensionStructureNode"/> which represents a node in the tree which
        /// describes a document structure.
        /// </summary>
        /// <param name="sourceFormatId">
        ///     <see cref="SourceFormat"/> id.
        /// </param>
        /// <param name="dimensionStructureId">
        ///     <see cref="DimensionStructure"/> id.
        /// </param>
        /// <param name="cancellationToken">
        ///     <see cref="CancellationToken"/> token.
        /// </param>
        /// <returns>
        ///     Task containing <see cref="DimensionStructure"/>.
        /// </returns>
        /// <exception cref="MasterDataBusinessLogicSourceFormatDatabaseOperationException">
        ///     Error happened during database operation.
        /// </exception>
        Task<DimensionStructureNode> GetNodeAsync(
            long sourceFormatId,
            long dimensionStructureId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Queries the active <see cref="SourceFormat"/>s from the database and returns a list of them.
        /// </summary>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        /// <returns>
        /// Returns a <see cref="Task{TResult}"/> contains a <see cref="List{T}"/> of <see cref="SourceFormat"/>s
        /// objects. All of them active.
        ///
        /// If there are no active <see cref="SourceFormat"/> in the system it returns with an empty list.
        /// </returns>
        /// <exception cref="MasterDataBusinessLogicSourceFormatDatabaseOperationException">
        ///     Error happened during database operation.
        /// </exception>
        Task<List<SourceFormat>> GetActivesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Queries the inactive <see cref="SourceFormat"/>s from the database and returns a list of them.
        /// </summary>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        /// <returns>
        /// Returns a <see cref="Task{TResult}"/> containing a <see cref="List{T}"/> of <see cref="SourceFormat"/>s
        /// objects. All of them inactive.
        ///
        /// If there is not inactive <see cref="SourceFormat"/> in the system, then it returns with an empty
        /// <see cref="List{T}"/>.
        /// </returns>
        /// <exception cref="MasterDataBusinessLogicSourceFormatDatabaseOperationException">
        ///     Error happened during database operation.
        /// </exception>
        Task<List<SourceFormat>> GetInActives(CancellationToken cancellationToken = default);

        /// <summary>
        /// Inactivates the given <see cref="SourceFormat"/>.
        /// </summary>
        /// <param name="sourceFormat">
        /// The <see cref="SourceFormat"/> going to be inactivated.
        /// </param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
        /// <returns><see cref="Task"/> represents the operation result.</returns>
        /// <exception cref="MasterDataBusinessLogicSourceFormatDatabaseOperationException">
        ///     Error happened during database operation.
        /// </exception>
        Task InactivateAsync(
            SourceFormat sourceFormat,
            CancellationToken cancellationToken = default);
    }
}