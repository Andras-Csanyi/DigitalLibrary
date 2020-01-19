using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalLibrary.MasterData.WebApi.Client.Client
{
    using DomainModel;

    public partial interface IMasterDataHttpClient
    {
        Task<List<Dimension>> GetAllActiveDimensions();

        Task<Dimension> AddDimensionAsync(Dimension dimension);

        Task<List<Dimension>> GetDimensionsWithoutStructure();
    }
}