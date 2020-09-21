namespace DigitalLibrary.Utils.MasterDataTestHelper.Tools.DimensionStructureLinkedListHelper
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;

    public partial class DimensionStructureLinkedListHelper
    {
        public async Task<SourceFormat> AddDimensionStructureToNodeAsync(DimensionStructure childDimensionStructure,
                                                                         SourceFormat sourceFormat,
                                                                         string nodeName)
        {
            if (sourceFormat.RootDimensionStructure.ChildDimensionStructures.Any())
            {
                await IterateThroughAndAddAsync(sourceFormat.RootDimensionStructure.ChildDimensionStructures,
                        nodeName,
                        childDimensionStructure)
                   .ConfigureAwait(false);
            }

            return sourceFormat;
        }

        private async Task IterateThroughAndAddAsync(
            ICollection<DimensionStructure> childDimensionStructures,
            string nodeName,
            DimensionStructure childDimensionStructure)
        {
            foreach (DimensionStructure dimensionStructure in childDimensionStructures)
            {
                if (dimensionStructure.Name.Equals(nodeName))
                {
                    dimensionStructure.ChildDimensionStructures.Add(childDimensionStructure);
                }

                if (dimensionStructure.ChildDimensionStructures.Any())
                {
                    await IterateThroughAndAddAsync(dimensionStructure.ChildDimensionStructures,
                            nodeName,
                            childDimensionStructure)
                       .ConfigureAwait(false);
                }
            }
        }
    }
}