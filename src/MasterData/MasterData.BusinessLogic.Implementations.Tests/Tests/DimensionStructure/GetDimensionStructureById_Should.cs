using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.Tests.DimensionStructure
{
    [ExcludeFromCodeCoverage]
    public class GetDimensionStructureById_Should : TestBase
    {
        private const string TestInfo = nameof(GetDimensionStructureById_Should);

        public GetDimensionStructureById_Should() : base(TestInfo)
        {
        }

        public async Task ReturnDimensionStructure_WhenThereAreNoChildElems()
        {
        }

        public async Task ReturnDimensionStructure_WithFirstLevelChilds_WhenOnlyFirstLevelChildsAre()
        {
        }

        public async Task ReturnDimensionStructure_WithFirstSecondLevelChildsToo()
        {
        }

        public async Task ReturnDimensionStructure_WithComplexChildStructure()
        {
        }
    }
}