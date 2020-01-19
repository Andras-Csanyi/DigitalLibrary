namespace DigitalLibrary.MasterData.WebApi.Client
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DomainModel;

    public partial interface IMasterDataHttpClient
    {
        Task<List<Dimension>> GetAllActiveDimensions();

        Task<Dimension> AddDimensionAsync(Dimension dimension);

        Task<List<Dimension>> GetDimensionsWithoutStructure();
    }
}