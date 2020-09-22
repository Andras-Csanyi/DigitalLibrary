namespace DigitalLibrary.Utils.MasterDataTestHelper.Tools.DimensionStructureLinkedListHelper
{
    using System.Collections;
    using System.Collections.Generic;
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

        Task<bool> IsDimensionStructureChildOfRootDimensionStructureAsync(
            ICollection<DimensionStructure> dimensionStructures,
            DimensionStructure childDimensionStructure);
    }
}