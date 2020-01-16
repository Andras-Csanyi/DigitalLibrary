namespace DigitalLibrary.IaC.MasterData.BusinessLogic.Implementations.Tests.Tests.Dimension
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    [ExcludeFromCodeCoverage]
    public class DeleteDimensionAsync_Should : TestBase
    {
        protected const string TestInfo = nameof(DeleteDimensionAsync_Should);

        public DeleteDimensionAsync_Should() : base(TestInfo)
        {
        }

        public async Task DeleteDimension_WhenThereAreNoRelatedDimensionValues()
        {
        }

        public async Task DeleteDimension_AndDeleteDimensionValues_WhenTheyArentConnectToOtherDimensions()
        {
        }

        public async Task DeleteDimension_AndInactivateDimDimValRelations_IfDimValConnectedToOtherDimension()
        {
        }

        public async Task DeleteDimension_AndManagesMultipleTypeDimensionvalues()
        {
        }
    }
}