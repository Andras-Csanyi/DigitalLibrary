// <copyright file="IMasterDataBusinessLogic.Dimension.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DomainModel;

    public partial interface IMasterDataBusinessLogic
    {
        Task<Dimension> AddDimensionAsync(Dimension dimension);

        Task DeleteDimensionAsync(Dimension dimension);

        Task<List<Dimension>> GetDimensionsAsync();

        Task<List<Dimension>> GetDimensionsWithoutStructureAsync();

        Task<Dimension> UpdateDimensionAsync(Dimension dimension);
    }
}