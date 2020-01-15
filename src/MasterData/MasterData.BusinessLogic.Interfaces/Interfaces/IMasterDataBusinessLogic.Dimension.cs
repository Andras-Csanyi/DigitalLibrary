namespace DigitalLibrary.IaC.MasterData.BusinessLogic.Interfaces.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DomainModel.DomainModel;

    public partial interface IMasterDataBusinessLogic
    {
        Task<List<Dimension>> GetActiveDimensionsAsync();

        Task<List<Dimension>> GetDimensionsWithoutStructureAsync();
    }
}