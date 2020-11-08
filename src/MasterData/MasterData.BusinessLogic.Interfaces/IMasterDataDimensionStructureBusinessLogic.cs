// <copyright file="IMasterDataBusinessLogic.DimensionStructure.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Interfaces
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.ViewModels;
    using DigitalLibrary.MasterData.DomainModel;

    public interface IMasterDataDimensionStructureBusinessLogic
    {
        /// <summary>
        ///     Adds a new <see cref="DimensionStructure" /> entity to the system.
        /// </summary>
        /// <param name="dimensionStructure">
        ///     The object containing the new data.
        /// </param>
        /// <returns>
        ///     Returns an instance of the added <see cref="DimensionStructure" />.
        /// </returns>
        /// <exception cref="MasterDataBusinessLogicDimensionStructureDatabaseOperationException">
        ///     If any part of the operation fails.
        /// </exception>
        Task<DimensionStructure> AddAsync(DimensionStructure dimensionStructure);

        Task<DimensionStructure> AddChildDimensionStructureAsync(
            long childDimensionStructureId,
            long parentDimensionId);

        Task<DimensionStructure> AddChildDimensionStructureAsync(
            DimensionStructure childDimensionStructure,
            long parentDimensionId);

        /// <summary>
        ///     Adds <see cref="DimensionStructure" /> to the <see cref="DimensionStructure" /> tree as child.
        /// </summary>
        /// <param name="childId">DimensionStructure to be added as child.</param>
        /// <param name="parentId">Parent DimensionStructure.</param>
        /// <param name="sourceFormatId">SourceFormat.</param>
        /// <returns>Result or exception.</returns>
        Task AddDimensionStructureToParentAsChildInSourceFormatAsync(long childId, long parentId, long sourceFormatId);

        /// <summary>
        ///     It adds <see cref="DimensionStructure" /> to a <see cref="SourceFormat" /> as its
        ///     RootDimensionStructure.
        /// </summary>
        /// <param name="dimensionStructureId">The DimensionStructure will be added.</param>
        /// <param name="sourceFormatId">The SourceFormat it wil be added to.</param>
        /// <returns>The dimension structure.</returns>
        Task<DimensionStructure> AddDimensionStructureToSourceFormatAsRootDimensionStructureAsync(
            long dimensionStructureId,
            long sourceFormatId);

        Task<DimensionStructure> AddDimensionToDimensionStructureAsync(long dimensionId, long dimensionStructureId);

        /// <summary>
        /// Inactivates the given <see cref="DimensionStructure"/> object.
        /// </summary>
        /// <param name="dimensionStructure">
        ///    The provided payload's ID vlaue identifies which <see cref="DimensionStructure"/> object will be
        /// inactivated in the system. This operation doesn't concern other properties of the provided object.
        /// </param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
        /// <returns>
        ///    Returns <see cref="Task"/> representing result of asynchronous operation.
        /// </returns>
        /// <exception cref="IMasterDataDimensionStructureBusinessLogicDatabaseOperationException">
        ///    Any error happens.
        /// </exception>
        Task InactivateAsync(
            DimensionStructure dimensionStructure,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Returns list of <see cref="DimensionStructure" /> where the parent is the given
        ///     <see cref="DimensionStructure" />. <see cref="SourceFormat" /> defines the scope of the query.
        /// </summary>
        /// <param name="parentId">Parent Id.</param>
        /// <param name="sourceFormatId">Source format id.</param>
        /// <returns>List.</returns>
        Task<List<DimensionStructure>> GetChildrenOfDimensionStructureInSourceFormatScopeAsync(
            long parentId,
            long sourceFormatId);

        /// <summary>
        ///     Returns <see cref="DimensionStructure" /> having given Id.
        ///     When there is no <see cref="DimensionStructure" /> returns null.
        /// </summary>
        /// <param name="dimensionStructure">
        /// ID of this object identifies which <see cref="DimensionStructure"/> is requested.
        /// </param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
        /// <returns>
        ///    Returns <see cref="Task{TResult}"/> representing result of asynchronous operation.
        /// It contains a <see cref="DimensionStructure"/> when the object is found.
        /// It contains <see cref="null"/> when there is no object having the ID value.
        /// </returns>
        /// /// <exception cref="MasterDataBusinessLogicDimensionStructureDatabaseOperationException">
        ///     If any part of the operation fails.
        /// </exception>
        Task<DimensionStructure> GetByIdAsync(
            DimensionStructure dimensionStructure,
            CancellationToken cancellationToken = default);

        Task<DimensionStructure> GetDimensionStructureByNameAsync(string name);

        /// <summary>
        ///     It returns with <see cref="DimensionStructure" /> and the related <see cref="SourceFormat" />
        ///     entities included too.
        /// </summary>
        /// <param name="name">Name of the DimensionStructure.</param>
        /// <returns>The DimensionStructure.</returns>
        Task<DimensionStructure> GetDimensionStructureByNameWithSourceFormatsAsync(string name);

        Task<List<DimensionStructure>> GetDimensionStructuresAsync();

        Task<List<DimensionStructure>> GetDimensionStructuresByIdsAsync(
            DimensionStructureQueryObject dimensionStructureQueryObject);

        Task RemoveChildDimensionStructureAsync(long removedDimensionStructure, long parentDimensionStructure);

        Task RemoveDimensionFromDimensionStructureAsync(long dimensionId, long dimensionStructureId);

        Task RemoveDimensionStructureFromSourceFormatAsync(long dimensionStructureId, long sourceFormatId);

        Task<DimensionStructure> UpdateDimensionStructureAsync(DimensionStructure dimensionStructure);

        /// <summary>
        ///     Returns with amount of <see cref="DimensionStructure" /> in the system.
        ///     Both active and inactive included.
        /// </summary>
        /// <returns>Amount.</returns>
        Task<int> GetCountAsync();

        /// <summary>
        ///     Returns with amount of active <see cref="DimensionStructure" /> in the system.
        /// </summary>
        /// <returns>Amount.</returns>
        Task<int> GetActiveCountAsync();

        /// <summary>
        ///     Returns list of active <see cref="DimensionStructure" /> in the system.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>
        ///     Returns with <see cref="Task{TResult}" /> containing a <see cref="List{T}" /> of
        ///     <see cref="DimensionStructure" />.
        /// </returns>
        /// <exception cref="MasterDataBusinessLogicDimensionStructureDatabaseOperationException">
        ///     If any operation fails during querying data.
        /// </exception>
        Task<List<DimensionStructure>> GetActivesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        ///     Deletes a <see cref="DimensionStructure" /> from a <see cref="SourceFormat" />'s tree.
        /// </summary>
        /// <param name="id">Id of the DimensionStructure to be deleted.</param>
        /// <param name="sourceFormatId">SourceFormat id where the tree belongs to.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Void or exception.</returns>
        Task DeleteFromTree(
            long id,
            long sourceFormatId,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Queries <see cref="DimensionStructure" />s from the database.
        ///     <remarks>
        ///         The list of <see cref="DimensionStructure" /> contains both active and inactive items.
        ///     </remarks>
        /// </summary>
        /// <param name="cancellationToken">
        ///     Cancellation token.
        /// </param>
        /// <returns>
        ///     Returns a task containing a list of active and inactive <see cref="DimensionStructure" />s.
        /// </returns>
        /// <exception cref="MasterDataBusinessLogicDimensionStructureDatabaseOperationException">
        ///     When any operation fails.
        /// </exception>
        Task<List<DimensionStructure>> GetAllAsync(CancellationToken cancellationToken = default);

        /// <summary>
        ///     Queries inactive <see cref="DimensionStructure" /> from the database.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>
        ///     Returns a <see cref="Task{TResult}" /> which contains the <see cref="List{T}" /> of
        ///     <see cref="DimensionStructure" />s.
        /// </returns>
        /// <exception cref="MasterDataBusinessLogicDimensionStructureDatabaseOperationException">
        ///     When any operation fails.
        /// </exception>
        Task<List<DimensionStructure>> GetInactivesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes the object having the same Id as the provided one has from the database.
        /// </summary>
        /// <param name="tobeDeleted">
        ///    Object representing the object going to be deleted from the database.
        /// From this object only the ID property is considered. Any other properties are ignored.
        /// </param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
        /// <returns>
        ///    Returns <see cref="Task"/> representing value of an asynchronous operation.
        /// </returns>
        /// /// <exception cref="MasterDataBusinessLogicDimensionStructureDatabaseOperationException">
        ///     When any operation fails.
        /// </exception>
        Task DeleteAsync(
            DimensionStructure tobeDeleted,
            CancellationToken cancellationToken = default);
    }
}