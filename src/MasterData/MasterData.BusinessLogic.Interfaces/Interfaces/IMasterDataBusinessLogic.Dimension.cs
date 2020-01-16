using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalLibrary.MasterData.DomainModel.DomainModel;

namespace DigitalLibrary.MasterData.BusinessLogic.Interfaces.Interfaces
{
    public partial interface IMasterDataBusinessLogic
    {
        Task<List<Dimension>> GetActiveDimensionsAsync();

        Task<List<Dimension>> GetDimensionsWithoutStructureAsync();
    }
}