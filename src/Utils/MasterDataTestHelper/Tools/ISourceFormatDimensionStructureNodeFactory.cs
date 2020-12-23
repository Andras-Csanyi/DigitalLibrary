namespace DigitalLibrary.Utils.MasterDataTestHelper.Tools
{
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

    public interface ISourceFormatDimensionStructureNodeFactory
    {
        SourceFormatDimensionStructureNode Create(KeyResultKeyEntity instance);
    }
}