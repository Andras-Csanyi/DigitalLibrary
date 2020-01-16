using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalLibrary.MasterData.DomainModel.DomainModel;

namespace DigitalLibrary.MasterData.WebApi.Client.Client
{
    public partial interface IMasterDataHttpClient
    {
        Task<List<DimensionStructure>> GetTopDimensionStructuresAsync();

        Task<DimensionStructure> ModifyTopDimensionStructureAsync(DimensionStructure dimensionStructure);

        Task<DimensionStructure> AddTopDimensionStructureAsync(DimensionStructure dimensionStructure);

        Task DeleteTopDimensionStructureAsync(DimensionStructure dimensionStructure);
    }
}