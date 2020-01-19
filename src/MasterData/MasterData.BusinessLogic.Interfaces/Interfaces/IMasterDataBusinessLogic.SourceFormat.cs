namespace DigitalLibrary.MasterData.BusinessLogic.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DomainModel;

    public partial interface IMasterDataBusinessLogic
    {
        Task<DimensionStructure> AddSourceFormatAsync(DimensionStructure dimensionStructure);

        Task<List<DimensionStructure>> GetSourceFormatAsync();

        Task<long> CountSourceFormatAsync();

        Task<DimensionStructure> UpdateSourceFormatAsync(DimensionStructure dimensionStructure);
    }
}