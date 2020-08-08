namespace DigitalLibrary.MasterData.WebApi.Client
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DomainModel;

    public partial interface IMasterDataHttpClient
    {
        Task<Dimension> AddDimensionAsync(Dimension dimension);

        Task DeleteDimensionAsync(Dimension dimension);

        Task<Dimension> GetDimensionByIdAsync(long id);

        Task<List<Dimension>> GetDimensionsAsync();

        Task<List<Dimension>> GetDimensionsWithoutStructure();

        Task<Dimension> UpdateDimensionAsync(Dimension dimension);
    }
}