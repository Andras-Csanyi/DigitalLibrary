// <copyright file="IMasterDataBusinessLogic.Dimension.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;

    public interface IMasterDataDimensionBusinessLogic
    {
        Task<Dimension> AddDimensionAsync(Dimension dimension);

        Task DeleteDimensionAsync(Dimension dimension);

        Task<List<Dimension>> GetDimensionsAsync();

        Task<List<Dimension>> GetDimensionsWithoutStructureAsync();

        Task<Dimension> UpdateDimensionAsync(Dimension dimension);

        Task<Dimension> GetValuesOfADimensionAsync(long dimensionId);

        Task<Dimension> GetDimensionByIdAsync(long dimensionId);

        Task RemoveDimensionFromDimensionStructureAsync(long dimensionId, long dimensionStructureId);
    }
}