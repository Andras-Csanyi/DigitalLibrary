namespace DigitalLibrary.MasterData.WebApi.Client
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DomainModel;

    public partial interface IMasterDataHttpClient
    {
        Task<List<Dimension>> GetDimensionsAsync();

        Task<Dimension> AddDimensionAsync(Dimension dimension);

        Task<List<Dimension>> GetDimensionsWithoutStructure();

        Task DeleteDimensionAsync(long dimensionId);

        Task<Dimension> UpdateDimensionAsync(Dimension dimension);
    }
}