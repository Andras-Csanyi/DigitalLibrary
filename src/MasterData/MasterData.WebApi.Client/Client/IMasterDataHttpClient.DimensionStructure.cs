namespace DigitalLibrary.IaC.MasterData.WebApi.Client.Client
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DomainModel.DomainModel;

    public partial interface IMasterDataHttpClient
    {
        Task<DimensionStructure> ModifyDimensionStructureAsync(DimensionStructure dimensionStructure);

        Task<List<DimensionStructure>> GetDimensionStructuresAsync();

        Task DeleteDimensionStructureAsync(DimensionStructure dimensionStructure);

        Task<DimensionStructure> AddDimensionStructureAsync(DimensionStructure dimensionStructure);
    }
}