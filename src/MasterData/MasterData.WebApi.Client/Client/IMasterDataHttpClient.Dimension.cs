// <copyright file="IMasterDataHttpClient.Dimension.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.WebApi.Client
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DigitalLibrary.MasterData.DomainModel;

    public partial interface IMasterDataHttpClient
    {
        Task<Dimension> AddDimensionAsync(Dimension dimension);

        Task DeleteDimensionAsync(Dimension dimension);

        Task<Dimension> GetDimensionByIdAsync(long id);

        Task<List<Dimension>> GetDimensionsAsync();

        Task<List<Dimension>> GetDimensionsWithoutStructure();

        Task<Dimension> UpdateDimensionAsync(Dimension dimension);
    }
}