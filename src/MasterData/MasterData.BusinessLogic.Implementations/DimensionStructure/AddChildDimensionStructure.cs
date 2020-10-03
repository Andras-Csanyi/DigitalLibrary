// <copyright file="AddChildDimensionStructure.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.DimensionStructure
{
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;

    public partial class MasterDataDimensionStructureBusinessLogic
    {
        public async Task<DimensionStructure> AddChildDimensionStructureAsync(
            long childDimensionStructureId,
            long parentDimensionId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<DimensionStructure> AddChildDimensionStructureAsync(
            DimensionStructure childDimensionStructure,
            long parentDimensionId)
        {
            throw new System.NotImplementedException();
        }
    }
}