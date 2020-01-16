using System;
using System.Threading.Tasks;
using DigitalLibrary.MasterData.DomainModel.DomainModel;

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Implementations
{
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