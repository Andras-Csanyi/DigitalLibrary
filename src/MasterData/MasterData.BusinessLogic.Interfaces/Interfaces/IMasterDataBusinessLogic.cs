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

        /// <summary>
        /// Updates <see cref="DimensionValue"/>.
        /// It takes the dimension id and based on the value looks up for the value and updates it.
        /// Only that <see cref="DimensionValue"/> will be updated which has connection to the given
        /// <see cref="Dimension"/>. If the value has connection to multiple <see cref="Dimension"/> than
        /// these connection will be separated and rebuilt.
        /// </summary>
        /// <param name="dimensionId">Dimension.</param>
        /// <param name="oldDimensionValue">Old value.</param>
        /// <param name="newDimensionValue">New value.</param>
        /// <returns>Updated dimension value.</returns>
        Task<DimensionValue> ModifyDimensionValueAsync(
            long dimensionId,
            DimensionValue oldDimensionValue,
            DimensionValue newDimensionValue);

        Task<DimensionStructure> ReorderDimensionsInDimensionStructureAsync(
            long dimensionStructureId,
            Dimension dimensionToBeInserted,
            int sortOrder);
    }
}