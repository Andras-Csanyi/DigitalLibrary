namespace DigitalLibrary.Utils.MasterDataTestHelper.Tools
{
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

    public class SourceFormatDimensionStructureNodeFactory : ISourceFormatDimensionStructureNodeFactory
    {
        public SourceFormatDimensionStructureNode Create(KeyResultKeyEntity instance)
        {
            return new SourceFormatDimensionStructureNode();
        }
    }
}