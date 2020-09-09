// <copyright file="IMasterDataBusinessLogic.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;

    /// <summary>
    ///     MasterDataBusinessLogic interface.
    ///     Describes database operations.
    ///     This interface is split into pieces where a piece concerns a domain model in MasterData domain.
    /// </summary>
    public partial interface IMasterDataBusinessLogic
    {
        Task<DimensionValue> AddDimensionValueAsync(DimensionValue dimensionValue, long dimensionId);

        Task<long> CountDimensionValuesAsync();


        Task<Dimension> GetDimensionByIdAsync(long dimensionId);

        /// <summary>
        /// Returns list of <see cref="DimensionValue"/>.
        /// It doesn't return with related entities.
        /// </summary>
        /// <returns>List of DimensionValues.</returns>
        Task<List<DimensionValue>> GetDimensionValuesAsync();

        Task<Dimension> GetValuesOfADimensionAsync(long dimensionId);

        Task<DimensionValue> ModifyDimensionValueAsync(
            long dimensionId,
            DimensionValue oldDimensionValue,
            DimensionValue newDimensionvalue);

        Task<DimensionStructure> ReorderDimensionsInDimensionStructureAsync(
            long dimensionStructureId,
            Dimension dimensionToBeInserted,
            int sortOrder);
    }
}