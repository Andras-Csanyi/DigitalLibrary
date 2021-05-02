namespace DigitalLibrary.Utils.MasterDataTestHelper.Tools
{
    using System.Diagnostics.CodeAnalysis;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

    [ExcludeFromCodeCoverage]
    public class SourceFormatDimensionStructureNodeFactory : ISourceFormatDimensionStructureNodeFactory
    {
        public SourceFormatDimensionStructureNode Create(KeyResultKeyEntity instance)
        {
            return new SourceFormatDimensionStructureNode();
        }
    }
}