namespace DigitalLibrary.MasterData.BusinessLogic.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DomainModel;

    public partial interface IMasterDataBusinessLogic
    {
        Task<List<Dimension>> GetActiveDimensionsAsync();

        Task<List<Dimension>> GetDimensionsWithoutStructureAsync();
    }
}