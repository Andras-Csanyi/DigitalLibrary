// <copyright file="IMasterDataBusinessLogic.DimensionStructure.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.ViewModels;
    using DigitalLibrary.MasterData.DomainModel;

    public interface IMasterDataDimensionStructureBusinessLogic
    {
        Task<DimensionStructure> AddChildDimensionStructureAsync(
            long childDimensionStructureId,
            long parentDimensionId);

        Task<DimensionStructure> AddChildDimensionStructureAsync(
            DimensionStructure childDimensionStructure,
            long parentDimensionId);

        Task<DimensionStructure> AddAsync(DimensionStructure dimensionStructure);

        /// <summary>
        /// It adds <see cref="DimensionStructure"/> to a <see cref="SourceFormat"/> as its
        /// RootDimensionStructure.
        /// </summary>
        /// <param name="dimensionStructureId">The DimensionStructure will be added.</param>
        /// <param name="sourceFormatId">The SourceFormat it wil be added to.</param>
        /// <returns>The dimension structure.</returns>
        Task<DimensionStructure> AddDimensionStructureToSourceFormatAsRootDimensionStructureAsync(
            long dimensionStructureId,
            long sourceFormatId);

        Task<DimensionStructure> AddDimensionToDimensionStructureAsync(long dimensionId, long dimensionStructureId);

        Task DeleteDimensionStructureAsync(DimensionStructure dimensionStructure);

        /// <summary>
        /// Returns <see cref="DimensionStructure"/> having given Id.
        /// When there is no <see cref="DimensionStructure"/> returns null.
        /// </summary>
        /// <param name="dimensionStructure">Query object.</param>
        /// <returns>DimensionStructure or null.</returns>
        Task<DimensionStructure> GetDimensionStructureByIdAsync(DimensionStructure dimensionStructure);

        Task<DimensionStructure> GetDimensionStructureByNameAsync(string name);

        /// <summary>
        /// It returns with <see cref="DimensionStructure"/> and the related <see cref="SourceFormat"/>
        /// entities included too.
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
        /// Adds <see cref="DimensionStructure"/> to the <see cref="DimensionStructure"/> tree as child.
        /// </summary>
        /// <param name="childId">DimensionStructure to be added as child.</param>
        /// <param name="parentId">Parent DimensionStructure.</param>
        /// <param name="sourceFormatId">SourceFormat.</param>
        /// <returns>Result or exception.</returns>
        Task AddDimensionStructureToParentAsChildInSourceFormatAsync(long childId, long parentId, long sourceFormatId);

        /// <summary>
        /// Returns list of <see cref="DimensionStructure"/> where the parent is the given
        /// <see cref="DimensionStructure"/>. <see cref="SourceFormat"/> defines the scope of the query.
        /// </summary>
        /// <param name="parentId">Parent Id.</param>
        /// <param name="sourceFormatId">Source format id.</param>
        /// <returns>List.</returns>
        Task<List<DimensionStructure>> GetChildrenOfDimensionStructureInSourceFormatScopeAsync(
            long parentId,
            long sourceFormatId);
    }
}