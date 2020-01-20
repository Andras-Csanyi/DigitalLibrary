namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.DimensionStructure
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    [ExcludeFromCodeCoverage]
    public class Get_DimensionStructureById_Should : TestBase
    {
        private const string TestInfo = nameof(Get_DimensionStructureById_Should);

        public Get_DimensionStructureById_Should() : base(TestInfo)
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