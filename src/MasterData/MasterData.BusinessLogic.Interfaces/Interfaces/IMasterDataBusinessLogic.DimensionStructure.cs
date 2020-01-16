namespace DigitalLibrary.IaC.MasterData.BusinessLogic.Interfaces.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DomainModel.DomainModel;

    public partial interface IMasterDataBusinessLogic
    {
        Task<DimensionStructure> AddDimensionStructureAsync(DimensionStructure dimensionStructure);

        Task DeleteDimensionStructureAsync(DimensionStructure dimensionStructure);

        Task<DimensionStructure> UpdateDimensionStructureAsync(DimensionStructure dimensionStructure);

        Task<List<DimensionStructure>> GetDimensionStructuresAsync();
    }
}