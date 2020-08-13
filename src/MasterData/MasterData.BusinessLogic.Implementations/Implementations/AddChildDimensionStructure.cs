// Digital Library project
// https://github.com/SayusiAndo/DigitalLibrary
// Licensed under MIT License

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations
{
    using System.Threading.Tasks;

    using DomainModel;

    public partial class MasterDataBusinessLogic
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