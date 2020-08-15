// <copyright file="ReorderDimensionsInDimensionStructure.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations
{
    using System;
    using System.Threading.Tasks;

    using DomainModel;

    public partial class MasterDataBusinessLogic
    {
        public async Task<DimensionStructure> ReorderDimensionsInDimensionStructureAsync(
            long dimensionStructureId,
            Dimension dimensionToBeInserted,
            int sortOrder)
        {
            throw new NotImplementedException();
        }
    }
}