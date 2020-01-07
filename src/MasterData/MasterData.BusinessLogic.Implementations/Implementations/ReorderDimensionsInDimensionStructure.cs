namespace DigitalLibrary.IaC.MasterData.BusinessLogic.Implementations.Implementations
{
    using System;
    using System.Threading.Tasks;

    using DomainModel.DomainModel;

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