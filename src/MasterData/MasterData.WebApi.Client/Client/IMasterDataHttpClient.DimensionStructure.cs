using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalLibrary.MasterData.DomainModel.DomainModel;

namespace DigitalLibrary.MasterData.WebApi.Client.Client
{
    public partial interface IMasterDataHttpClient
    {
        Task<DimensionStructure> ModifyDimensionStructureAsync(DimensionStructure dimensionStructure);

        Task<List<DimensionStructure>> GetDimensionStructuresAsync();

        Task DeleteDimensionStructureAsync(DimensionStructure dimensionStructure);

        Task<DimensionStructure> AddDimensionStructureAsync(DimensionStructure dimensionStructure);
        
        Task<DimensionStructure> UpdateDimensionStructure(DimensionStructure updatedDimensionStructure);
    }
}