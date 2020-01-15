namespace DigitalLibrary.IaC.MasterData.WebApi.Client.Client
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DomainModel.DomainModel;

    public partial interface IMasterDataHttpClient
    {
        Task<List<Dimension>> GetAllActiveDimensions();

        Task<Dimension> AddDimensionAsync(Dimension dimension);

        Task<List<Dimension>> GetDimensionsWithoutStructure();
    }
}