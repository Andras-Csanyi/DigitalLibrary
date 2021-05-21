// <copyright file="IMasterDataBusinessLogic.DimensionStructure.cs" company="Andras Csanyi">
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
    ///     DimensionStructure interface describing business logic methods.
    /// </summary>
    public interface IMasterDataDimensionStructureBusinessLogic
    {
        /// <summary>
        ///     Adds a new <see cref="DimensionStructure"/> entity to the system.
        /// </summary>
        /// <param name="dimensionStructure">
        ///     The object containing the new data.
        /// </param>
        /// <param name="cancellationToken"> <see cref="CancellationToken"/>. </param>
        /// <returns>
        ///     Returns an instance of the added <see cref="DimensionStructure"/>.
        /// </returns>
        /// <exception cref="MasterDataBusinessLogicDimensionStructureDatabaseOperationException">
        ///     If any part of the operation fails.
        /// </exception>
        Task<DimensionStructure> AddAsync(
            DimensionStructure dimensionStructure,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Inactivates the given <see cref="DimensionStructure"/> object.
        /// </summary>
        /// <param name="dimensionStructure">
        ///     The provided payload's ID vlaue identifies which <see cref="DimensionStructure"/> object will be
        ///     inactivated in the system. This operation doesn't concern other properties of the provided object.
        /// </param>
        /// <param name="cancellationToken"> <see cref="CancellationToken"/>. </param>
        /// <returns>
        ///     Returns <see cref="Task"/> representing result of asynchronous operation.
        /// </returns>
        /// <exception cref="IMasterDataDimensionStructureBusinessLogicDatabaseOperationException">
        ///     Any error happens.
        /// </exception>
        Task InactivateAsync(
            DimensionStructure dimensionStructure,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Returns <see cref="DimensionStructure"/> having given Id.
        ///     When there is no <see cref="DimensionStructure"/> returns null.
        /// </summary>
        /// <param name="dimensionStructure">
        ///     ID of this object identifies which <see cref="DimensionStructure"/> is requested.
        /// </param>
        /// <param name="cancellationToken"> <see cref="CancellationToken"/>. </param>
        /// <returns>
        ///     Returns <see cref="Task{TResult}"/> representing result of asynchronous operation.
        ///     It contains a <see cref="DimensionStructure"/> when the object is found.
        ///     It contains <see cref="null"/> when there is no object having the ID value.
        /// </returns>
        /// ///
        /// <exception cref="MasterDataBusinessLogicDimensionStructureDatabaseOperationException">
        ///     If any part of the operation fails.
        /// </exception>
        Task<DimensionStructure> GetByIdAsync(
            DimensionStructure dimensionStructure,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Updates <see cref="DimensionStructure"/> in the database.
        ///     The Id marks the object going to be updated, other properties hold the new values.
        /// </summary>
        /// <param name="dimensionStructure">
        ///     Payload <see cref="DimensionStructure"/> object which marks the target and holds the new data.
        /// </param>
        /// <param name="cancellationToken"> <see cref="CancellationToken"/>. </param>
        /// <returns>
        ///     Returns with <see cref="Task{TResult}"/> containing the modified <see cref="DimensionStructure"/>.
        /// </returns>
        /// <exception cref="MasterDataBusinessLogicDimensionStructureDatabaseOperationException">
        ///     If any operation fails during querying data.
        /// </exception>
        Task<DimensionStructure> UpdateAsync(
            DimensionStructure dimensionStructure,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Returns with amount of active <see cref="DimensionStructure"/> in the system.
        /// </summary>
        /// <returns> Amount. </returns>
        Task<int> GetActiveCountAsync();

        /// <summary>
        ///     Returns list of active <see cref="DimensionStructure"/> in the system.
        /// </summary>
        /// <param name="cancellationToken"> Cancellation token. </param>
        /// <returns>
        ///     Returns with <see cref="Task{TResult}"/> containing a <see cref="List{T}"/> of
        ///     <see cref="DimensionStructure"/>.
        /// </returns>
        /// <exception cref="MasterDataBusinessLogicDimensionStructureDatabaseOperationException">
        ///     If any operation fails during querying data.
        /// </exception>
        Task<List<DimensionStructure>> GetActivesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        ///     Queries <see cref="DimensionStructure"/>s from the database.
        ///     <remarks>
        ///         The list of <see cref="DimensionStructure"/> contains both active and inactive items.
        ///     </remarks>
        /// </summary>
        /// <param name="cancellationToken">
        ///     Cancellation token.
        /// </param>
        /// <returns>
        ///     Returns a task containing a list of active and inactive <see cref="DimensionStructure"/>s.
        /// </returns>
        /// <exception cref="MasterDataBusinessLogicDimensionStructureDatabaseOperationException">
        ///     When any operation fails.
        /// </exception>
        Task<List<DimensionStructure>> GetAllAsync(CancellationToken cancellationToken = default);

        /// <summary>
        ///     Queries inactive <see cref="DimensionStructure"/> from the database.
        /// </summary>
        /// <param name="cancellationToken"> Cancellation token. </param>
        /// <returns>
        ///     Returns a <see cref="Task{TResult}"/> which contains the <see cref="List{T}"/> of
        ///     <see cref="DimensionStructure"/>s.
        /// </returns>
        /// <exception cref="MasterDataBusinessLogicDimensionStructureDatabaseOperationException">
        ///     When any operation fails.
        /// </exception>
        Task<List<DimensionStructure>> GetInactivesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        ///     Deletes the object having the same Id as the provided one has from the database.
        /// </summary>
        /// <param name="tobeDeleted">
        ///     Object representing the object going to be deleted from the database.
        ///     From this object only the ID property is considered. Any other properties are ignored.
        /// </param>
        /// <param name="cancellationToken"> <see cref="CancellationToken"/>. </param>
        /// <returns>
        ///     Returns <see cref="Task"/> representing value of an asynchronous operation.
        /// </returns>
        /// ///
        /// <exception cref="MasterDataBusinessLogicDimensionStructureDatabaseOperationException">
        ///     When any operation fails.
        /// </exception>
        Task DeleteAsync(
            DimensionStructure tobeDeleted,
            CancellationToken cancellationToken = default);
    }
}
