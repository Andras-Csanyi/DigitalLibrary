namespace DigitalLibrary.Utils.MasterDataTestHelper.Tools.DimensionStructureLinkedListHelper
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;

    public partial class DimensionStructureLinkedListHelper
    {
        public async Task<bool> IsDimensionStructureChildOfRootDimensionStructureAsync(
            ICollection<DimensionStructure> dimensionStructures,
            DimensionStructure childDimensionStructure)
        {
            if (dimensionStructures.Any())
            {
                foreach (DimensionStructure dimensionStructure in dimensionStructures)
                {
                    if (dimensionStructure.Name.Equals(childDimensionStructure.Name))
                    {
                        return true;
                    }

                    if (dimensionStructure.ChildDimensionStructures != null)
                    {
                        if (dimensionStructure.ChildDimensionStructures.Any())
                        {
                            await IsDimensionStructureChildOfRootDimensionStructureAsync(
                                    dimensionStructure.ChildDimensionStructures,
                                    childDimensionStructure)
                               .ConfigureAwait(false);
                        }
                    }
                }
            }

            return false;
        }
    }
}