using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalLibrary.MasterData.DomainModel.DomainModel;

namespace DigitalLibrary.MasterData.BusinessLogic.Interfaces.Interfaces
{
    public partial interface IMasterDataBusinessLogic
    {
        Task<DimensionStructure> AddDimensionStructureAsync(DimensionStructure dimensionStructure);

        Task DeleteDimensionStructureAsync(DimensionStructure dimensionStructure);

        Task<DimensionStructure> UpdateDimensionStructureAsync(DimensionStructure dimensionStructure);

        Task<List<DimensionStructure>> GetDimensionStructuresAsync();
    }
}