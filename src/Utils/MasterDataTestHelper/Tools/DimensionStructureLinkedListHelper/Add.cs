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
                                                                         string parentNodeName)
        {
            DimensionStructureNode dimensionStructureNode = new DimensionStructureNode
            {
                ChildDimensionStructureId = childDimensionStructure.Id,
                ChildDimensionStructure = childDimensionStructure,
            };

            if (sourceFormat.RootDimensionStructure.Name.Equals(parentNodeName))
            {
                sourceFormat.RootDimensionStructure.ChildDimensionStructures2.Add(dimensionStructureNode);
                return sourceFormat;
            }

            if (sourceFormat.RootDimensionStructure.ChildDimensionStructures != null)
            {
                await IterateThroughAndAddAsync(sourceFormat.RootDimensionStructure.ChildDimensionStructures,
                        parentNodeName,
                        dimensionStructureNode)
                   .ConfigureAwait(false);
            }

            return sourceFormat;
        }

        private async Task IterateThroughAndAddAsync(
            ICollection<DimensionStructure> childDimensionStructures,
            string nodeName,
            DimensionStructureNode dimensionStructureNode)
        {
            foreach (DimensionStructure childdimensionStructure in childDimensionStructures)
            {
                if (childdimensionStructure.Name.Equals(nodeName))
                {
                    childdimensionStructure.ChildDimensionStructures2.Add(dimensionStructureNode);
                    break;
                }

                if (childdimensionStructure.ChildDimensionStructures.Any())
                {
                    await IterateThroughAndAddAsync(childdimensionStructure.ChildDimensionStructures,
                            nodeName,
                            dimensionStructureNode)
                       .ConfigureAwait(false);
                }
            }
        }
    }
}