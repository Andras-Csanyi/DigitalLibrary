namespace DigitalLibrary.MasterData.BusinessLogic.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DomainModel;

    public partial interface IMasterDataBusinessLogic
    {
        Task<DimensionValue> AddDimensionValueAsync(DimensionValue dimensionValue, long dimensionId);

        Task<Dimension> GetValuesOfADimensionAsync(long dimensionId);

        Task<DimensionValue> ModifyDimensionValueAsync(
            long dimensionId,
            DimensionValue oldDimensionValue,
            DimensionValue newDimensionvalue);

        Task<List<DimensionValue>> GetDimensionValuesAsync();

        Task<long> CountDimensionValuesAsync();


        Task<Dimension> GetDimensionByIdAsync(long dimensionId);

        Task<DimensionStructure> ReorderDimensionsInDimensionStructureAsync(
            long dimensionStructureId,
            Dimension dimensionToBeInserted,
            int sortOrder);


        Task<DimensionStructure> GetDimensionStructureById(long dimensionStructureId);
    }
}