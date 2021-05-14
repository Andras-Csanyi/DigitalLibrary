namespace DigitalLibrary.MasterData.BusinessLogic.Tests.Integration.SourceFormat
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using Xunit;
    using Xunit.Abstractions;

    [ExcludeFromCodeCoverage]
    public class AddDimensionStructureNodeAsync_Should : TestBase
    {
        [Fact]
        public async Task Add_ChildNodeToRootDsn()
        {
        }

        public AddDimensionStructureNodeAsync_Should(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
        }
    }
}