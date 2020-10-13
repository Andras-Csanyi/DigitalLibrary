namespace DigitalLibrary.Utils.MasterDataTestHelper
{
    using System;

    using DigitalLibrary.Utils.MasterDataTestHelper.Tools;

    public interface IMasterDataTestHelper
    {
        IDimensionStructureFactory DimensionStructureFactory { get; }

        ISourceFormatFactory SourceFormatFactory { get; }
    }

    public class MasterDataTestHelper : IMasterDataTestHelper
    {
        public MasterDataTestHelper(
            ISourceFormatFactory sourceFormatFactory,
            IDimensionStructureFactory dimensionStructureFactory)
        {
            SourceFormatFactory = sourceFormatFactory ?? throw new ArgumentNullException(
                $"{nameof(sourceFormatFactory)}");
            DimensionStructureFactory = dimensionStructureFactory ?? throw new ArgumentNullException(
                $"{nameof(dimensionStructureFactory)}");
        }

        public IDimensionStructureFactory DimensionStructureFactory { get; }

        public ISourceFormatFactory SourceFormatFactory { get; }
    }
}