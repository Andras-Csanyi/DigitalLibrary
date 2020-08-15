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

    public partial interface IMasterDataBusinessLogic
    {
        Task<DimensionStructure> AddChildDimensionStructureAsync(
            long childDimensionStructureId,
            long parentDimensionId);

        Task<DimensionStructure> AddChildDimensionStructureAsync(
            DimensionStructure childDimensionStructure,
            long parentDimensionId);

        Task<DimensionStructure> AddDimensionStructureAsync(DimensionStructure dimensionStructure);

        Task<DimensionStructure> AddDimensionStructureToSourceformatAsync(
            long dimensionStructureId,
            long sourceFormatId);

        Task<DimensionStructure> AddDimensionToDimensionStructureAsync(long dimensionId, long dimensionStructureId);

        Task DeleteDimensionStructureAsync(DimensionStructure dimensionStructure);

        Task<DimensionStructure> GetDimensionStructureByIdAsync(
            DimensionStructureQueryObject dimensionStructureQueryObject);

        Task<DimensionStructure> GetDimensionStructureByNameAsync(string name);

        Task<List<DimensionStructure>> GetDimensionStructuresAsync();

        Task<List<DimensionStructure>> GetDimensionStructuresByIdsAsync(
            DimensionStructureQueryObject dimensionStructureQueryObject);

        Task RemoveChildDimensionStructureAsync(long removedDimensionStructure, long parentDimensionStructure);

        Task RemoveDimensionFromDimensionStructureAsync(long dimensionId, long dimensionStructureId);

        Task RemoveDimensionStructureFromSourceFormatAsync(long dimensionStructureId, long sourceFormatId);

        Task<DimensionStructure> UpdateDimensionStructureAsync(DimensionStructure dimensionStructure);
    }
}