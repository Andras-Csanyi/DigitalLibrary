using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalLibrary.MasterData.DomainModel.DomainModel;

namespace DigitalLibrary.MasterData.WebApi.Client.Client
{
    public partial interface IMasterDataHttpClient
    {
        Task<List<Dimension>> GetAllActiveDimensions();

        Task<Dimension> AddDimensionAsync(Dimension dimension);

        Task<List<Dimension>> GetDimensionsWithoutStructure();

        Task<DimensionStructure> UpdateDimensionStructure(DimensionStructure updatedDimensionStructure);
    }
}