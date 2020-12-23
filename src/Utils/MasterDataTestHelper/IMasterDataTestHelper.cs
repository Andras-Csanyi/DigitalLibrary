namespace DigitalLibrary.Utils.MasterDataTestHelper
{
    using DigitalLibrary.Utils.MasterDataTestHelper.Tools;

    /// <summary>
    ///     MasterDataTestHelper which contains tools to deal with
    ///     cumbersome tasks during testing.
    /// </summary>
    public interface IMasterDataTestHelper
    {
        /// <summary>
        ///     Gets <see cref="DimensionStructure"> object factory.
        /// </summary>
        IDimensionStructureFactory DimensionStructureFactory { get; }

        /// <summary>
        ///     Gets <see cref="SourceFormat" /> object factory.
        /// </summary>
        ISourceFormatFactory SourceFormatFactory { get; }

        /// <summary>
        /// Gets instance of <see cref="SourceFormatDimensionStructureNodeFactory"/>.
        /// </summary>
        ISourceFormatDimensionStructureNodeFactory SourceFormatDimensionStructureNodeFactory { get; }
    }
}