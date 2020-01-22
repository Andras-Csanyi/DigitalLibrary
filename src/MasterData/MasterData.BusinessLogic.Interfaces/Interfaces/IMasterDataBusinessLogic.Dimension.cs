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

        Task<Dimension> ModifyDimensionAsync(long dimensionId, Dimension modifiedDimension);

        Task DeleteDimensionAsync(long dimensionId);
    }
}