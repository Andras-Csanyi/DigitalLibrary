namespace DigitalLibrary.MasterData.BusinessLogic.Interfaces
{
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;

    public interface IMasterDataDimensionValueBusinessLogic
    {
        Task<DimensionValue> AddDimensionValueAsync(
            DimensionValue dimensionValue,
            long dimensionId);

        Task<long> CountDimensionValuesAsync();

        Task<DimensionValue> ModifyDimensionValueAsync(
            long dimensionId,
            DimensionValue oldDimensionValue,
            DimensionValue newDimensionValue);
    }
}
