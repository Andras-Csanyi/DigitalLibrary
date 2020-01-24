namespace DigitalLibrary.MasterData.BusinessLogic.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DomainModel;

    public partial interface IMasterDataBusinessLogic
    {
        Task<List<Dimension>> GetDimensionsAsync();

        Task<List<Dimension>> GetDimensionsWithoutStructureAsync();

        Task<Dimension> AddDimensionAsync(Dimension dimension);

        Task<Dimension> UpdateDimensionAsync(Dimension dimension);

        Task DeleteDimensionAsync(Dimension dimension);
    }
}