namespace DigitalLibrary.MasterData.WebApi.Client
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;

    public partial interface IMasterDataHttpClient
    {
        Task<List<Dimension>> GetDimensionsAsync();

        Task<Dimension> AddDimensionAsync(Dimension dimension);

        Task<List<Dimension>> GetDimensionsWithoutStructure();

        Task DeleteDimensionAsync(Dimension dimension);

        Task<Dimension> UpdateDimensionAsync(Dimension dimension);
    }
}