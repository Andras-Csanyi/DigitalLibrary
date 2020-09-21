namespace DigitalLibrary.Utils.MasterDataTestHelper.Tools.DimensionStructureLinkedListHelper
{
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;

    public interface IDimensionStructureLinkedListHelper
    {
        Task<SourceFormat> AddDimensionStructureToNodeAsync(
            DimensionStructure childDimensionStructure,
            SourceFormat sourceFormat,
            string nodeName);

        Task<DimensionStructure> GetChildDimensionStructureFromGivenNode(
            SourceFormat result,
            string nodeName,
            string dimensionStructureName);
    }
}