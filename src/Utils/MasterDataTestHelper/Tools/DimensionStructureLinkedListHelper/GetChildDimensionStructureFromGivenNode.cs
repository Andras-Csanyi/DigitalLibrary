namespace DigitalLibrary.Utils.MasterDataTestHelper.Tools.DimensionStructureLinkedListHelper
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;

    public partial class DimensionStructureLinkedListHelper
    {
        public async Task<DimensionStructure> GetChildDimensionStructureFromGivenNode(
            SourceFormat result,
            string nodeName,
            string dimensionStructureName)
        {
            if (result.RootDimensionStructure.ChildDimensionStructures.Any())
            {
                if (result.RootDimensionStructure.Name.Equals(nodeName))
                {
                    return result.RootDimensionStructure.ChildDimensionStructures.FirstOrDefault(
                        p => p.Name.Equals(dimensionStructureName));
                }

                return await FindChildDimensionStructureUnderGivenNode(
                        result.RootDimensionStructure.ChildDimensionStructures,
                        nodeName,
                        dimensionStructureName)
                   .ConfigureAwait(false);
            }

            return null;
        }

        private async Task<DimensionStructure> FindChildDimensionStructureUnderGivenNode(
            ICollection<DimensionStructure> dimensionStructures,
            string nodeName,
            string dimensionStructureName)
        {
            foreach (DimensionStructure dimensionStructure in dimensionStructures)
            {
                if (dimensionStructure.Name.Equals(nodeName))
                {
                    if (dimensionStructure.ChildDimensionStructures.Any())
                    {
                        DimensionStructure result = dimensionStructure.ChildDimensionStructures.FirstOrDefault(
                            p => p.Name.Equals(dimensionStructureName));

                        if (result != null)
                        {
                            return result;
                        }

                        return await FindChildDimensionStructureUnderGivenNode(
                                dimensionStructure.ChildDimensionStructures,
                                nodeName,
                                dimensionStructureName)
                           .ConfigureAwait(false);
                    }
                }
            }

            return null;
        }
    }
}