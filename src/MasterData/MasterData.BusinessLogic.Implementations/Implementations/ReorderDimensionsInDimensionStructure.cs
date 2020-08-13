// Digital Library project
// https://github.com/SayusiAndo/DigitalLibrary
// Licensed under MIT License

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