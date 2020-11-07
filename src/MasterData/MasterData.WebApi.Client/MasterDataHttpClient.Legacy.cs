namespace DigitalLibrary.MasterData.WebApi.Client
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.ViewModels;
    using DigitalLibrary.MasterData.DomainModel;

    public partial class MasterDataHttpClient
    {
        public async Task<Dimension> AddDimensionAsync(Dimension dimension)
        {
            throw new System.NotImplementedException();
        }

        public async Task DeleteDimensionAsync(Dimension dimension)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Dimension> GetDimensionByIdAsync(long id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Dimension>> GetDimensionsAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Dimension>> GetDimensionsWithoutStructure()
        {
            throw new System.NotImplementedException();
        }

        public async Task<Dimension> UpdateDimensionAsync(Dimension dimension)
        {
            throw new System.NotImplementedException();
        }

        public async Task<DimensionStructure> AddDimensionStructureAsync(DimensionStructure dimensionStructure)
        {
            throw new System.NotImplementedException();
        }

        public async Task DeleteDimensionStructureAsync(DimensionStructure dimensionStructure)
        {
            throw new System.NotImplementedException();
        }

        public async Task<DimensionStructure> GetDimensionStructureByIdAsync(
            DimensionStructureQueryObject dimensionStructureQueryObject)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<DimensionStructure>> GetDimensionStructuresAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<DimensionStructure>> GetDimensionStructuresAsync(
            DimensionStructureQueryObject queryObject)
        {
            throw new System.NotImplementedException();
        }

        public async Task<DimensionStructure> ModifyDimensionStructureAsync(DimensionStructure dimensionStructure)
        {
            throw new System.NotImplementedException();
        }

        public async Task<DimensionStructure> UpdateDimensionStructureAsync(
            DimensionStructure updatedDimensionStructure)
        {
            throw new System.NotImplementedException();
        }
    }
}