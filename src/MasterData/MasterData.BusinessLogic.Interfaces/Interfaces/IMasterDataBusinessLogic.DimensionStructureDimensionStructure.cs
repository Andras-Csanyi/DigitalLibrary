// <copyright file="IMasterDataBusinessLogic.DimensionStructureDimensionStructure.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Interfaces
{
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;

    public partial interface IMasterDataBusinessLogic
    {
        Task<DimensionStructureDimensionStructure> AddDimensionStructureDimensionStructureAsync(
            DimensionStructureDimensionStructure dimensionStructureDimensionStructure);
    }
}