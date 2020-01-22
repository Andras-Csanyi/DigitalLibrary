namespace DigitalLibrary.MasterData.BusinessLogic.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DomainModel;

    public partial interface IMasterDataBusinessLogic
    {
        Task<Dimension> AddDimensionAsync(Dimension dimension);

        Task<DimensionValue> AddDimensionValueAsync(DimensionValue dimensionValue, long dimensionId);

        Task<Dimension> GetValuesOfADimensionAsync(long dimensionId);

        Task<DimensionValue> ModifyDimensionValueAsync(
            long dimensionId,
            DimensionValue oldDimensionValue,
            DimensionValue newDimensionvalue);

        Task<List<DimensionValue>> GetDimensionValuesAsync();

        Task<long> CountDimensionValuesAsync();

        Task<Dimension> ModifyDimensionAsync(long dimensionId, Dimension modifiedDimension);

        Task<Dimension> GetDimensionByIdAsync(long dimensionId);

        Task<DimensionStructure> ReorderDimensionsInDimensionStructureAsync(
            long dimensionStructureId,
            Dimension dimensionToBeInserted,
            int sortOrder);

        Task DeleteDimensionAsync(long dimensionId);

        Task<DimensionStructure> GetDimensionStructureById(long dimensionStructureId);
    }
}