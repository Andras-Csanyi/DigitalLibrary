namespace DigitalLibrary.MasterData.BusinessLogic.Interfaces
{
    using System.Threading.Tasks;

    using DomainModel;

    public partial interface IMasterDataBusinessLogic
    {
        Task<DimensionStructureDimensionStructure> AddDimensionStructureDimensionStructureAsync(
            DimensionStructureDimensionStructure dimensionStructureDimensionStructure);
    }
}