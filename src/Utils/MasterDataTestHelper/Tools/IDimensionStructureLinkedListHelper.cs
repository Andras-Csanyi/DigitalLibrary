namespace DigitalLibrary.Utils.MasterDataTestHelper.Tools
{
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;

    public interface IDimensionStructureLinkedListHelper
    {
        Task<SourceFormat> AddDimensionStructureToNodeAsync(
            DimensionStructure childDimensionStructure,
            SourceFormat sourceFormat,
            string nodeName);
    }
}