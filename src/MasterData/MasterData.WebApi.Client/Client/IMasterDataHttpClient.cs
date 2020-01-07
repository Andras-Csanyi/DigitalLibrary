namespace DigitalLibrary.IaC.MasterData.WebApi.Client.Client
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DomainModel.DomainModel;

    public interface IMasterDataHttpClient
    {
        Task<List<DimensionStructure>> GetTopDimensionStructuresAsync();

        Task<DimensionStructure> ModifyTopDimensionStructureAsync(DimensionStructure dimensionStructure);

        Task<DimensionStructure> AddTopDimensionStructureAsync(DimensionStructure dimensionStructure);

        Task DeleteTopDimensionStructureAsync(DimensionStructure dimensionStructure);
    }
}